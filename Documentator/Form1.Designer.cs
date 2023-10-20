namespace TATOR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkedListBoxEstandar = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxCustom = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGenerateExcel = new System.Windows.Forms.Button();
            this.buttonSelectAllStandard = new System.Windows.Forms.Button();
            this.buttonSelectAllCustom = new System.Windows.Forms.Button();
            this.buttonDesselectAllStandar = new System.Windows.Forms.Button();
            this.buttonDeselectAllCustom = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxOrdenAlfa = new System.Windows.Forms.CheckBox();
            this.checkBoxPicklistValue = new System.Windows.Forms.CheckBox();
            this.checkBoxFormulas = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFicheroSalida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPijama = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxEstandar
            // 
            this.checkedListBoxEstandar.CheckOnClick = true;
            this.checkedListBoxEstandar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxEstandar.FormattingEnabled = true;
            this.checkedListBoxEstandar.Location = new System.Drawing.Point(16, 72);
            this.checkedListBoxEstandar.Name = "checkedListBoxEstandar";
            this.checkedListBoxEstandar.Size = new System.Drawing.Size(349, 310);
            this.checkedListBoxEstandar.TabIndex = 0;
            // 
            // checkedListBoxCustom
            // 
            this.checkedListBoxCustom.CheckOnClick = true;
            this.checkedListBoxCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxCustom.FormattingEnabled = true;
            this.checkedListBoxCustom.Location = new System.Drawing.Point(383, 72);
            this.checkedListBoxCustom.Name = "checkedListBoxCustom";
            this.checkedListBoxCustom.Size = new System.Drawing.Size(349, 310);
            this.checkedListBoxCustom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Standar Objects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Custom Objects";
            // 
            // buttonGenerateExcel
            // 
            this.buttonGenerateExcel.Location = new System.Drawing.Point(29, 398);
            this.buttonGenerateExcel.Name = "buttonGenerateExcel";
            this.buttonGenerateExcel.Size = new System.Drawing.Size(203, 23);
            this.buttonGenerateExcel.TabIndex = 4;
            this.buttonGenerateExcel.Text = "Generate Excel";
            this.buttonGenerateExcel.UseVisualStyleBackColor = true;
            this.buttonGenerateExcel.Click += new System.EventHandler(this.buttonGenerateExcel_Click);
            // 
            // buttonSelectAllStandard
            // 
            this.buttonSelectAllStandard.Location = new System.Drawing.Point(16, 400);
            this.buttonSelectAllStandard.Name = "buttonSelectAllStandard";
            this.buttonSelectAllStandard.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAllStandard.TabIndex = 5;
            this.buttonSelectAllStandard.Text = "Select All";
            this.buttonSelectAllStandard.UseVisualStyleBackColor = true;
            this.buttonSelectAllStandard.Click += new System.EventHandler(this.buttonSelectAllStandard_Click);
            // 
            // buttonSelectAllCustom
            // 
            this.buttonSelectAllCustom.Location = new System.Drawing.Point(383, 399);
            this.buttonSelectAllCustom.Name = "buttonSelectAllCustom";
            this.buttonSelectAllCustom.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAllCustom.TabIndex = 6;
            this.buttonSelectAllCustom.Text = "Select All";
            this.buttonSelectAllCustom.UseVisualStyleBackColor = true;
            this.buttonSelectAllCustom.Click += new System.EventHandler(this.buttonSelectAllCustom_Click);
            // 
            // buttonDesselectAllStandar
            // 
            this.buttonDesselectAllStandar.Location = new System.Drawing.Point(290, 399);
            this.buttonDesselectAllStandar.Name = "buttonDesselectAllStandar";
            this.buttonDesselectAllStandar.Size = new System.Drawing.Size(75, 23);
            this.buttonDesselectAllStandar.TabIndex = 7;
            this.buttonDesselectAllStandar.Text = "Deselect All";
            this.buttonDesselectAllStandar.UseVisualStyleBackColor = true;
            this.buttonDesselectAllStandar.Click += new System.EventHandler(this.buttonDesselectAllStandar_Click);
            // 
            // buttonDeselectAllCustom
            // 
            this.buttonDeselectAllCustom.Location = new System.Drawing.Point(657, 400);
            this.buttonDeselectAllCustom.Name = "buttonDeselectAllCustom";
            this.buttonDeselectAllCustom.Size = new System.Drawing.Size(75, 23);
            this.buttonDeselectAllCustom.TabIndex = 8;
            this.buttonDeselectAllCustom.Text = "Deselect All";
            this.buttonDeselectAllCustom.UseVisualStyleBackColor = true;
            this.buttonDeselectAllCustom.Click += new System.EventHandler(this.buttonDeselectAllCustom_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxPijama);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBoxFicheroSalida);
            this.panel1.Controls.Add(this.pictureBoxLoading);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.checkBoxOrdenAlfa);
            this.panel1.Controls.Add(this.checkBoxPicklistValue);
            this.panel1.Controls.Add(this.checkBoxFormulas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonGenerateExcel);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(765, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 461);
            this.panel1.TabIndex = 9;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Image = global::TATOR.Properties.Resources.ajax_loader3;
            this.pictureBoxLoading.Location = new System.Drawing.Point(109, 333);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(40, 37);
            this.pictureBoxLoading.TabIndex = 11;
            this.pictureBoxLoading.TabStop = false;
            this.pictureBoxLoading.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(34, 379);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 10;
            // 
            // checkBoxOrdenAlfa
            // 
            this.checkBoxOrdenAlfa.AutoSize = true;
            this.checkBoxOrdenAlfa.Checked = true;
            this.checkBoxOrdenAlfa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOrdenAlfa.Location = new System.Drawing.Point(36, 117);
            this.checkBoxOrdenAlfa.Name = "checkBoxOrdenAlfa";
            this.checkBoxOrdenAlfa.Size = new System.Drawing.Size(143, 17);
            this.checkBoxOrdenAlfa.TabIndex = 8;
            this.checkBoxOrdenAlfa.Text = "Ordenar Alfabeticamente";
            this.checkBoxOrdenAlfa.UseVisualStyleBackColor = true;
            // 
            // checkBoxPicklistValue
            // 
            this.checkBoxPicklistValue.AutoSize = true;
            this.checkBoxPicklistValue.Location = new System.Drawing.Point(36, 94);
            this.checkBoxPicklistValue.Name = "checkBoxPicklistValue";
            this.checkBoxPicklistValue.Size = new System.Drawing.Size(178, 17);
            this.checkBoxPicklistValue.TabIndex = 7;
            this.checkBoxPicklistValue.Text = "Mostrar picklist con clave - valor";
            this.checkBoxPicklistValue.UseVisualStyleBackColor = true;
            // 
            // checkBoxFormulas
            // 
            this.checkBoxFormulas.AutoSize = true;
            this.checkBoxFormulas.Checked = true;
            this.checkBoxFormulas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFormulas.Location = new System.Drawing.Point(36, 71);
            this.checkBoxFormulas.Name = "checkBoxFormulas";
            this.checkBoxFormulas.Size = new System.Drawing.Size(103, 17);
            this.checkBoxFormulas.TabIndex = 6;
            this.checkBoxFormulas.Text = "Mostrar formulas";
            this.checkBoxFormulas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opciones:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Choose";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxFicheroSalida
            // 
            this.textBoxFicheroSalida.Location = new System.Drawing.Point(19, 182);
            this.textBoxFicheroSalida.Name = "textBoxFicheroSalida";
            this.textBoxFicheroSalida.Size = new System.Drawing.Size(144, 20);
            this.textBoxFicheroSalida.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Destination folder";
            // 
            // checkBoxPijama
            // 
            this.checkBoxPijama.AutoSize = true;
            this.checkBoxPijama.Checked = true;
            this.checkBoxPijama.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPijama.Location = new System.Drawing.Point(36, 140);
            this.checkBoxPijama.Name = "checkBoxPijama";
            this.checkBoxPijama.Size = new System.Drawing.Size(95, 17);
            this.checkBoxPijama.TabIndex = 15;
            this.checkBoxPijama.Text = "Mostrar Pijama";
            this.checkBoxPijama.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonDeselectAllCustom);
            this.Controls.Add(this.buttonDesselectAllStandar);
            this.Controls.Add(this.buttonSelectAllCustom);
            this.Controls.Add(this.buttonSelectAllStandard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxCustom);
            this.Controls.Add(this.checkedListBoxEstandar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Documentator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxEstandar;
        private System.Windows.Forms.CheckedListBox checkedListBoxCustom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGenerateExcel;
        private System.Windows.Forms.Button buttonSelectAllStandard;
        private System.Windows.Forms.Button buttonSelectAllCustom;
        private System.Windows.Forms.Button buttonDesselectAllStandar;
        private System.Windows.Forms.Button buttonDeselectAllCustom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxOrdenAlfa;
        private System.Windows.Forms.CheckBox checkBoxPicklistValue;
        private System.Windows.Forms.CheckBox checkBoxFormulas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxFicheroSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxPijama;
    }
}

