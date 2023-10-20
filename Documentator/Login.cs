using Salesforce.Common;
using Salesforce.Common.Models;
using Salesforce.Force;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TATOR
{
    public partial class Login : Form
    {

        public string user { get; set; }
        public string pass { get; set; }

        
        public Login()
        {
            InitializeComponent();            
        }

        private async void button1_Click(object sender, EventArgs e)
        {            
            //Leemos los 2 valores y hacemos login en salesforce
            user = this.textBoxUserName.Text;
            pass = this.textBoxPassword.Text;

            //user = "Sistemas.vol@iberostar.com";
            //pass = "Wacawaca316";

             var url = this.checkBoxSandBox.Checked
                ? "https://test.salesforce.com/services/oauth2/token"
                : "https://login.salesforce.com/services/oauth2/token";

            var auth = new AuthenticationClient();

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                await auth.UsernamePasswordAsync(Constantes.ConsumerKey, Constantes.ConsumerSecret, this.user, this.pass, url);
                SalesforceSesion.Instancia.token = auth.AccessToken;
                SalesforceSesion.Instancia.url = auth.InstanceUrl;
                SalesforceSesion.Instancia.api = auth.ApiVersion;

               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                this.labelError.Text = "No se ha podido conectar con salesforce";
                //this.DialogResult = DialogResult.No;
            }                   

        }

        

    }
}
