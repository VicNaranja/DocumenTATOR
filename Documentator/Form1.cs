using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TATOR
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> listaObjetosEstandar = new Dictionary<int, string>();
        Dictionary<int, string> listaObjetosCustom = new Dictionary<int, string>();

        private SynchronizationContext m_SynchronizationContext;

        public Form1()
        {
            InitializeComponent();
            m_SynchronizationContext = SynchronizationContext.Current;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBoxLoading.Visible = false;
            this.textBoxFicheroSalida.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var login = new Login();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var client = new ForceClient(SalesforceSesion.Instancia.url, SalesforceSesion.Instancia.token, SalesforceSesion.Instancia.api);

                var result = await client.GetObjectsAsync<dynamic>();
                
                var standarCounter = 0;
                var customCounter = 0;
                //Cargamos los combos
                this.checkedListBoxEstandar.Items.Clear();
                this.checkedListBoxCustom.Items.Clear();
                foreach (var sobject in result.SObjects)
                {
                    if (sobject.urls.layouts != null)
                    {
                        if (!sobject.custom.Value)
                        {
                            listaObjetosEstandar.Add(standarCounter,sobject.name.Value);
                            standarCounter++;
                            this.checkedListBoxEstandar.Items.Add(sobject.label.Value + " (" + sobject.name.Value + ")");
                        }
                        else
                        {
                            listaObjetosCustom.Add(customCounter, sobject.name.Value);
                            customCounter++;
                            this.checkedListBoxCustom.Items.Add(sobject.label.Value + " (" + sobject.name.Value + ")");
                        }
                    }
                }                              

            }
            else
            {
                this.Close();
            }

        }

        private async void buttonGenerateExcel_Click(object sender, EventArgs e)
        {
            this.pictureBoxLoading.Visible = true;
            var client = new ForceClient(SalesforceSesion.Instancia.url, SalesforceSesion.Instancia.token, SalesforceSesion.Instancia.api);
            this.labelStatus.Text = "Iniciando Documentator";

            List<dynamic> listaDescribe = new List<dynamic>();
            List<ObjetoExcel> listaObjetoExcel = new List<ObjetoExcel>();
            //recuperamos sobject estandar
            for (var i = 0; i < this.checkedListBoxEstandar.CheckedIndices.Count; i++)
            {
                var name = listaObjetosEstandar[checkedListBoxEstandar.CheckedIndices[i]];
                var result = await client.DescribeAsync<dynamic>(name);

                this.labelStatus.Text = "Guardando " + name;
                var objetoExcel = new ObjetoExcel();
                objetoExcel.NombreObjeto = name;
                objetoExcel.ListaCampos = generateInfoObject(result.fields);
                if (this.checkBoxOrdenAlfa.Checked)
                    objetoExcel.ListaCampos.Sort((x, y) => string.Compare(x.NombreApi, y.NombreApi));
                listaObjetoExcel.Add(objetoExcel);
            }

            for (var i = 0; i < this.checkedListBoxCustom.CheckedIndices.Count; i++)
            {
                var name = listaObjetosCustom[checkedListBoxCustom.CheckedIndices[i]];
                var result = await client.DescribeAsync<dynamic>(name);

                this.labelStatus.Text = "Guardando " + name;
                var objetoExcel = new ObjetoExcel();
                objetoExcel.NombreObjeto = name;
                objetoExcel.ListaCampos = generateInfoObject(result.fields);
                if (this.checkBoxOrdenAlfa.Checked)
                    objetoExcel.ListaCampos.Sort((x, y) => string.Compare(x.NombreApi, y.NombreApi));
                listaObjetoExcel.Add(objetoExcel);
            }

            this.labelStatus.Text = "Generando Excel...";
         
            if (
                 await Task<bool>.Run(() =>
                 {
                     return generarExcel(listaObjetoExcel);
                 })   
               )
            {
                this.labelStatus.Text = "Excel Generado!!";
            }

            this.pictureBoxLoading.Visible = false;
            
            //FINITO
        }

        private List<Info> generateInfoObject(dynamic fields)
        {
            var result = new List<Info>();

            //recorremos los campos del objeto recuperado
            foreach (var field in fields)
            {
                var info = new Info();
                info.Label = field.label.Value;
                info.NombreApi = field.name.Value;
                info.Tipo = field.type.Value;

                if (field.unique.Value)
                    info.Unico = "√";
                else
                    info.Unico = "X";

                if (info.Tipo == "string")
                {
                    info.Tipo = info.Tipo + " (" + field.length.Value + ")";
                }
                if (field.calculatedFormula.Value != null)
                {
                    if (this.checkBoxFormulas.Checked)
                        info.InformacionAdicional = field.calculatedFormula.Value;
                    info.Tipo = info.Tipo + "(formula)";
                }

                if (info.Tipo == "picklist")
                {
                    //recorremos picklistvalues
                    var picklist = "";
                    foreach(var picklistvalue in field.picklistValues)
                    {
                        if (this.checkBoxPicklistValue.Checked)
                            picklist = picklist + "*" + picklistvalue.value + " - " + picklistvalue.label + "\n";
                        else
                            picklist = picklist + "*" + picklistvalue.label + "\n";
                    }

                    info.InformacionAdicional = picklist.TruncateDots(1000);
                }

                result.Add(info);
            }

            return result;

        }

        private bool generarExcel(List<ObjetoExcel> listaObjetosExcel)
        {
            var resultado = false;
            try
            {
                ExcelHelpers.ExportToExcel(listaObjetosExcel, this.textBoxFicheroSalida.Text, "Documentator.xlsx",this.checkBoxPijama.Checked);
                resultado = true;
            }
            catch(Exception ex)
            {
                m_SynchronizationContext.Post((@object) =>
                {
                    this.labelStatus.Text = (string)@object;
                }, ex.Message);
                
            }
            return resultado;

        }


        private void buttonSelectAllStandard_Click(object sender, EventArgs e)
        {
            for(var i = 0;i< this.checkedListBoxEstandar.Items.Count;i++)
            {
                this.checkedListBoxEstandar.SetItemChecked(i, true);
            }
        }

        private void buttonDesselectAllStandar_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < this.checkedListBoxEstandar.Items.Count; i++)
            {
                this.checkedListBoxEstandar.SetItemChecked(i, false);
            }
        }

        private void buttonSelectAllCustom_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < this.checkedListBoxCustom.Items.Count; i++)
            {
                this.checkedListBoxCustom.SetItemChecked(i, true);
            }
        }

        private void buttonDeselectAllCustom_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < this.checkedListBoxCustom.Items.Count; i++)
            {
                this.checkedListBoxCustom.SetItemChecked(i, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.FolderBrowserDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxFicheroSalida.Text = FD.SelectedPath;                
            }
        }
    }
}
