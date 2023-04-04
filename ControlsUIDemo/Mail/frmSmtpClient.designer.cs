using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmSmtpClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmtpClient));
            this.txbFilename2 = new System.Windows.Forms.TextBox();
            this.btnAttachment2 = new System.Windows.Forms.Button();
            this.txbFilename1 = new System.Windows.Forms.TextBox();
            this.btnAttachment1 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txbBody = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txbSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txbMailTo = new System.Windows.Forms.TextBox();
            this.lblMailTo = new System.Windows.Forms.Label();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txbUserPassword = new System.Windows.Forms.TextBox();
            this.lblSenderPassword = new System.Windows.Forms.Label();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.lblSenderMail = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.txbDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.gbbDomain = new System.Windows.Forms.GroupBox();
            this.txbMailFrom = new System.Windows.Forms.TextBox();
            this.lblMailFrom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.gbbDomain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbFilename2
            // 
            this.txbFilename2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename2.Location = new System.Drawing.Point(132, 498);
            this.txbFilename2.Margin = new System.Windows.Forms.Padding(4);
            this.txbFilename2.Name = "txbFilename2";
            this.txbFilename2.Size = new System.Drawing.Size(452, 24);
            this.txbFilename2.TabIndex = 35;
            // 
            // btnAttachment2
            // 
            this.btnAttachment2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachment2.Location = new System.Drawing.Point(68, 498);
            this.btnAttachment2.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachment2.Name = "btnAttachment2";
            this.btnAttachment2.Size = new System.Drawing.Size(47, 28);
            this.btnAttachment2.TabIndex = 34;
            this.btnAttachment2.Text = "...";
            this.btnAttachment2.UseVisualStyleBackColor = true;
            // 
            // txbFilename1
            // 
            this.txbFilename1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename1.Location = new System.Drawing.Point(132, 465);
            this.txbFilename1.Margin = new System.Windows.Forms.Padding(4);
            this.txbFilename1.Name = "txbFilename1";
            this.txbFilename1.Size = new System.Drawing.Size(452, 24);
            this.txbFilename1.TabIndex = 33;
            // 
            // btnAttachment1
            // 
            this.btnAttachment1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachment1.Location = new System.Drawing.Point(68, 465);
            this.btnAttachment1.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachment1.Name = "btnAttachment1";
            this.btnAttachment1.Size = new System.Drawing.Size(47, 28);
            this.btnAttachment1.TabIndex = 32;
            this.btnAttachment1.Text = "...";
            this.btnAttachment1.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(492, 564);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 31;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(383, 565);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 28);
            this.btnEnviar.TabIndex = 30;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txbBody
            // 
            this.txbBody.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBody.Location = new System.Drawing.Point(132, 308);
            this.txbBody.Margin = new System.Windows.Forms.Padding(4);
            this.txbBody.Multiline = true;
            this.txbBody.Name = "txbBody";
            this.txbBody.Size = new System.Drawing.Size(452, 147);
            this.txbBody.TabIndex = 29;
            this.txbBody.Text = resources.GetString("txbBody.Text");
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBody.Location = new System.Drawing.Point(33, 313);
            this.lblBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(44, 17);
            this.lblBody.TabIndex = 28;
            this.lblBody.Text = "Body";
            // 
            // txbSubject
            // 
            this.txbSubject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSubject.Location = new System.Drawing.Point(132, 274);
            this.txbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txbSubject.Name = "txbSubject";
            this.txbSubject.Size = new System.Drawing.Size(452, 24);
            this.txbSubject.TabIndex = 27;
            this.txbSubject.Text = "Mensaje de prueba";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(33, 278);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(62, 17);
            this.lblSubject.TabIndex = 26;
            this.lblSubject.Text = "Subject";
            // 
            // txbMailTo
            // 
            this.txbMailTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMailTo.Location = new System.Drawing.Point(132, 241);
            this.txbMailTo.Margin = new System.Windows.Forms.Padding(4);
            this.txbMailTo.Name = "txbMailTo";
            this.txbMailTo.Size = new System.Drawing.Size(261, 24);
            this.txbMailTo.TabIndex = 25;
            this.txbMailTo.Text = "ccc@ccc.com";
            // 
            // lblMailTo
            // 
            this.lblMailTo.AutoSize = true;
            this.lblMailTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailTo.Location = new System.Drawing.Point(33, 245);
            this.lblMailTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailTo.Name = "lblMailTo";
            this.lblMailTo.Size = new System.Drawing.Size(24, 17);
            this.lblMailTo.TabIndex = 24;
            this.lblMailTo.Text = "To";
            // 
            // txbServer
            // 
            this.txbServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbServer.Location = new System.Drawing.Point(132, 17);
            this.txbServer.Margin = new System.Windows.Forms.Padding(4);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(452, 24);
            this.txbServer.TabIndex = 23;
            this.txbServer.Text = "mail.opcion.com.pe";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(33, 25);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(54, 17);
            this.lblServer.TabIndex = 22;
            this.lblServer.Text = "Server";
            // 
            // txbUserPassword
            // 
            this.txbUserPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserPassword.Location = new System.Drawing.Point(107, 84);
            this.txbUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserPassword.Name = "txbUserPassword";
            this.txbUserPassword.PasswordChar = '*';
            this.txbUserPassword.Size = new System.Drawing.Size(261, 24);
            this.txbUserPassword.TabIndex = 21;
            this.txbUserPassword.Text = "A123456789";
            // 
            // lblSenderPassword
            // 
            this.lblSenderPassword.AutoSize = true;
            this.lblSenderPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderPassword.Location = new System.Drawing.Point(8, 87);
            this.lblSenderPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderPassword.Name = "lblSenderPassword";
            this.lblSenderPassword.Size = new System.Drawing.Size(75, 17);
            this.lblSenderPassword.TabIndex = 20;
            this.lblSenderPassword.Text = "Password";
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(107, 50);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(261, 24);
            this.txbUsername.TabIndex = 19;
            this.txbUsername.Text = "aaa@aaa.com";
            // 
            // lblSenderMail
            // 
            this.lblSenderMail.AutoSize = true;
            this.lblSenderMail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMail.Location = new System.Drawing.Point(8, 54);
            this.lblSenderMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderMail.Name = "lblSenderMail";
            this.lblSenderMail.Size = new System.Drawing.Size(44, 17);
            this.lblSenderMail.TabIndex = 18;
            this.lblSenderMail.Text = "From";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(132, 50);
            this.nudPort.Margin = new System.Windows.Forms.Padding(4);
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(124, 22);
            this.nudPort.TabIndex = 36;
            this.nudPort.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(33, 53);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 17);
            this.lblPort.TabIndex = 37;
            this.lblPort.Text = "Port";
            // 
            // txbDomain
            // 
            this.txbDomain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDomain.Location = new System.Drawing.Point(105, 17);
            this.txbDomain.Margin = new System.Windows.Forms.Padding(4);
            this.txbDomain.Name = "txbDomain";
            this.txbDomain.Size = new System.Drawing.Size(264, 24);
            this.txbDomain.TabIndex = 38;
            this.txbDomain.Text = "WINDOWSDOM";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomain.Location = new System.Drawing.Point(8, 21);
            this.lblDomain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(61, 17);
            this.lblDomain.TabIndex = 39;
            this.lblDomain.Text = "Domain";
            // 
            // gbbDomain
            // 
            this.gbbDomain.Controls.Add(this.lblDomain);
            this.gbbDomain.Controls.Add(this.lblSenderMail);
            this.gbbDomain.Controls.Add(this.txbDomain);
            this.gbbDomain.Controls.Add(this.txbUsername);
            this.gbbDomain.Controls.Add(this.lblSenderPassword);
            this.gbbDomain.Controls.Add(this.txbUserPassword);
            this.gbbDomain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbbDomain.Location = new System.Drawing.Point(24, 75);
            this.gbbDomain.Margin = new System.Windows.Forms.Padding(4);
            this.gbbDomain.Name = "gbbDomain";
            this.gbbDomain.Padding = new System.Windows.Forms.Padding(4);
            this.gbbDomain.Size = new System.Drawing.Size(415, 123);
            this.gbbDomain.TabIndex = 40;
            this.gbbDomain.TabStop = false;
            // 
            // txbMailFrom
            // 
            this.txbMailFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMailFrom.Location = new System.Drawing.Point(132, 208);
            this.txbMailFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txbMailFrom.Name = "txbMailFrom";
            this.txbMailFrom.Size = new System.Drawing.Size(261, 24);
            this.txbMailFrom.TabIndex = 42;
            this.txbMailFrom.Text = "bbb@bbb.com";
            // 
            // lblMailFrom
            // 
            this.lblMailFrom.AutoSize = true;
            this.lblMailFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailFrom.Location = new System.Drawing.Point(33, 212);
            this.lblMailFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailFrom.Name = "lblMailFrom";
            this.lblMailFrom.Size = new System.Drawing.Size(44, 17);
            this.lblMailFrom.TabIndex = 41;
            this.lblMailFrom.Text = "From";
            // 
            // frmSmtpClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 607);
            this.Controls.Add(this.txbMailFrom);
            this.Controls.Add(this.lblMailFrom);
            this.Controls.Add(this.gbbDomain);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.txbFilename2);
            this.Controls.Add(this.btnAttachment2);
            this.Controls.Add(this.txbFilename1);
            this.Controls.Add(this.btnAttachment1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txbBody);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txbSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txbMailTo);
            this.Controls.Add(this.lblMailTo);
            this.Controls.Add(this.txbServer);
            this.Controls.Add(this.lblServer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSmtpClient";
            this.Text = "frmSmtpClient";
            this.Load += new System.EventHandler(this.frmSmtpClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.gbbDomain.ResumeLayout(false);
            this.gbbDomain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbFilename2;
        private Button btnAttachment2;
        private TextBox txbFilename1;
        private Button btnAttachment1;
        private Button btnCerrar;
        private Button btnEnviar;
        private TextBox txbBody;
        private Label lblBody;
        private TextBox txbSubject;
        private Label lblSubject;
        private TextBox txbMailTo;
        private Label lblMailTo;
        private TextBox txbServer;
        private Label lblServer;
        private TextBox txbUserPassword;
        private Label lblSenderPassword;
        private TextBox txbUsername;
        private Label lblSenderMail;
        private NumericUpDown nudPort;
        private Label lblPort;
        private TextBox txbDomain;
        private Label lblDomain;
        private GroupBox gbbDomain;
        private TextBox txbMailFrom;
        private Label lblMailFrom;
    }
}