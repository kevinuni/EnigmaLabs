namespace LicenseGenerator
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
            this.btnGenlicense = new System.Windows.Forms.Button();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.txbIdentificador = new System.Windows.Forms.TextBox();
            this.cbbLicenseType = new System.Windows.Forms.ComboBox();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.dtpExpiration = new System.Windows.Forms.DateTimePicker();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.txbLicense = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenlicense
            // 
            this.btnGenlicense.Location = new System.Drawing.Point(464, 375);
            this.btnGenlicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenlicense.Name = "btnGenlicense";
            this.btnGenlicense.Size = new System.Drawing.Size(100, 28);
            this.btnGenlicense.TabIndex = 0;
            this.btnGenlicense.Text = "Generar";
            this.btnGenlicense.UseVisualStyleBackColor = true;
            this.btnGenlicense.Click += new System.EventHandler(this.btnGenlicense_Click);
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(48, 42);
            this.lblIdentificador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(80, 16);
            this.lblIdentificador.TabIndex = 1;
            this.lblIdentificador.Text = "Identificador";
            // 
            // txbIdentificador
            // 
            this.txbIdentificador.Location = new System.Drawing.Point(167, 42);
            this.txbIdentificador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbIdentificador.Multiline = true;
            this.txbIdentificador.Name = "txbIdentificador";
            this.txbIdentificador.Size = new System.Drawing.Size(528, 95);
            this.txbIdentificador.TabIndex = 2;
            // 
            // cbbLicenseType
            // 
            this.cbbLicenseType.FormattingEnabled = true;
            this.cbbLicenseType.Items.AddRange(new object[] {
            "None",
            "Trial",
            "Standard",
            "Personal",
            "Floating",
            "Subscription"});
            this.cbbLicenseType.Location = new System.Drawing.Point(167, 177);
            this.cbbLicenseType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbLicenseType.Name = "cbbLicenseType";
            this.cbbLicenseType.Size = new System.Drawing.Size(308, 24);
            this.cbbLicenseType.TabIndex = 3;
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.AutoSize = true;
            this.lblLicenseType.Location = new System.Drawing.Point(48, 181);
            this.lblLicenseType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(35, 16);
            this.lblLicenseType.TabIndex = 4;
            this.lblLicenseType.Text = "Tipo";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(48, 145);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 16);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Nombre";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(167, 145);
            this.txbName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(528, 22);
            this.txbName.TabIndex = 6;
            // 
            // dtpExpiration
            // 
            this.dtpExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiration.Location = new System.Drawing.Point(167, 210);
            this.dtpExpiration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpExpiration.Name = "dtpExpiration";
            this.dtpExpiration.Size = new System.Drawing.Size(265, 22);
            this.dtpExpiration.TabIndex = 7;
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(48, 218);
            this.lblExpiration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(70, 16);
            this.lblExpiration.TabIndex = 8;
            this.lblExpiration.Text = "Expiración";
            // 
            // txbLicense
            // 
            this.txbLicense.Location = new System.Drawing.Point(167, 242);
            this.txbLicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbLicense.Multiline = true;
            this.txbLicense.Name = "txbLicense";
            this.txbLicense.ReadOnly = true;
            this.txbLicense.Size = new System.Drawing.Size(528, 109);
            this.txbLicense.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(596, 375);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbLicense);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.dtpExpiration);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLicenseType);
            this.Controls.Add(this.cbbLicenseType);
            this.Controls.Add(this.txbIdentificador);
            this.Controls.Add(this.lblIdentificador);
            this.Controls.Add(this.btnGenlicense);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenlicense;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.TextBox txbIdentificador;
        private System.Windows.Forms.ComboBox cbbLicenseType;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.DateTimePicker dtpExpiration;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.TextBox txbLicense;
        private System.Windows.Forms.Button btnGuardar;
    }
}

