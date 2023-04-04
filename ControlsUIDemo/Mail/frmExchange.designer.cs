using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmExchange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchange));
            this.lblMailFrom = new System.Windows.Forms.Label();
            this.txbMailFrom = new System.Windows.Forms.TextBox();
            this.txbSenderPassword = new System.Windows.Forms.TextBox();
            this.lblSenderPassword = new System.Windows.Forms.Label();
            this.lblExchangeServer = new System.Windows.Forms.Label();
            this.txbExchangeServer = new System.Windows.Forms.TextBox();
            this.txbMailTo = new System.Windows.Forms.TextBox();
            this.lblMailTo = new System.Windows.Forms.Label();
            this.txbSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.txbBody = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAttachment1 = new System.Windows.Forms.Button();
            this.txbFilename1 = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txbFilename2 = new System.Windows.Forms.TextBox();
            this.btnAttachment2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMailFrom
            // 
            this.lblMailFrom.AutoSize = true;
            this.lblMailFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailFrom.Location = new System.Drawing.Point(27, 50);
            this.lblMailFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailFrom.Name = "lblMailFrom";
            this.lblMailFrom.Size = new System.Drawing.Size(44, 17);
            this.lblMailFrom.TabIndex = 0;
            this.lblMailFrom.Text = "From";
            // 
            // txbMailFrom
            // 
            this.txbMailFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMailFrom.Location = new System.Drawing.Point(125, 47);
            this.txbMailFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txbMailFrom.Name = "txbMailFrom";
            this.txbMailFrom.Size = new System.Drawing.Size(261, 24);
            this.txbMailFrom.TabIndex = 1;
            this.txbMailFrom.Text = "aaa@aaa.com";
            // 
            // txbSenderPassword
            // 
            this.txbSenderPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSenderPassword.Location = new System.Drawing.Point(125, 80);
            this.txbSenderPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbSenderPassword.Name = "txbSenderPassword";
            this.txbSenderPassword.PasswordChar = '*';
            this.txbSenderPassword.Size = new System.Drawing.Size(261, 24);
            this.txbSenderPassword.TabIndex = 3;
            this.txbSenderPassword.Text = "58253202";
            // 
            // lblSenderPassword
            // 
            this.lblSenderPassword.AutoSize = true;
            this.lblSenderPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderPassword.Location = new System.Drawing.Point(27, 84);
            this.lblSenderPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenderPassword.Name = "lblSenderPassword";
            this.lblSenderPassword.Size = new System.Drawing.Size(75, 17);
            this.lblSenderPassword.TabIndex = 2;
            this.lblSenderPassword.Text = "Password";
            // 
            // lblExchangeServer
            // 
            this.lblExchangeServer.AutoSize = true;
            this.lblExchangeServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeServer.Location = new System.Drawing.Point(27, 21);
            this.lblExchangeServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExchangeServer.Name = "lblExchangeServer";
            this.lblExchangeServer.Size = new System.Drawing.Size(54, 17);
            this.lblExchangeServer.TabIndex = 4;
            this.lblExchangeServer.Text = "Server";
            // 
            // txbExchangeServer
            // 
            this.txbExchangeServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbExchangeServer.Location = new System.Drawing.Point(125, 14);
            this.txbExchangeServer.Margin = new System.Windows.Forms.Padding(4);
            this.txbExchangeServer.Name = "txbExchangeServer";
            this.txbExchangeServer.Size = new System.Drawing.Size(452, 24);
            this.txbExchangeServer.TabIndex = 5;
            this.txbExchangeServer.Text = "https://outlook.office365.com/ews/exchange.asmx";
            // 
            // txbMailTo
            // 
            this.txbMailTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMailTo.Location = new System.Drawing.Point(125, 113);
            this.txbMailTo.Margin = new System.Windows.Forms.Padding(4);
            this.txbMailTo.Name = "txbMailTo";
            this.txbMailTo.Size = new System.Drawing.Size(261, 24);
            this.txbMailTo.TabIndex = 7;
            this.txbMailTo.Text = "bbb@bbb.com";
            // 
            // lblMailTo
            // 
            this.lblMailTo.AutoSize = true;
            this.lblMailTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailTo.Location = new System.Drawing.Point(27, 117);
            this.lblMailTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailTo.Name = "lblMailTo";
            this.lblMailTo.Size = new System.Drawing.Size(24, 17);
            this.lblMailTo.TabIndex = 6;
            this.lblMailTo.Text = "To";
            // 
            // txbSubject
            // 
            this.txbSubject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSubject.Location = new System.Drawing.Point(125, 146);
            this.txbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txbSubject.Name = "txbSubject";
            this.txbSubject.Size = new System.Drawing.Size(452, 24);
            this.txbSubject.TabIndex = 9;
            this.txbSubject.Text = "Mensaje de prueba";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(27, 150);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(62, 17);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "Subject";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBody.Location = new System.Drawing.Point(27, 185);
            this.lblBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(44, 17);
            this.lblBody.TabIndex = 10;
            this.lblBody.Text = "Body";
            // 
            // txbBody
            // 
            this.txbBody.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBody.Location = new System.Drawing.Point(125, 180);
            this.txbBody.Margin = new System.Windows.Forms.Padding(4);
            this.txbBody.Multiline = true;
            this.txbBody.Name = "txbBody";
            this.txbBody.Size = new System.Drawing.Size(452, 147);
            this.txbBody.TabIndex = 11;
            this.txbBody.Text = resources.GetString("txbBody.Text");
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(372, 414);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 28);
            this.btnEnviar.TabIndex = 12;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(481, 412);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAttachment1
            // 
            this.btnAttachment1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachment1.Location = new System.Drawing.Point(61, 337);
            this.btnAttachment1.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachment1.Name = "btnAttachment1";
            this.btnAttachment1.Size = new System.Drawing.Size(47, 28);
            this.btnAttachment1.TabIndex = 14;
            this.btnAttachment1.Text = "...";
            this.btnAttachment1.UseVisualStyleBackColor = true;
            this.btnAttachment1.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // txbFilename1
            // 
            this.txbFilename1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename1.Location = new System.Drawing.Point(125, 337);
            this.txbFilename1.Margin = new System.Windows.Forms.Padding(4);
            this.txbFilename1.Name = "txbFilename1";
            this.txbFilename1.Size = new System.Drawing.Size(452, 24);
            this.txbFilename1.TabIndex = 15;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // txbFilename2
            // 
            this.txbFilename2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename2.Location = new System.Drawing.Point(125, 370);
            this.txbFilename2.Margin = new System.Windows.Forms.Padding(4);
            this.txbFilename2.Name = "txbFilename2";
            this.txbFilename2.Size = new System.Drawing.Size(452, 24);
            this.txbFilename2.TabIndex = 17;
            // 
            // btnAttachment2
            // 
            this.btnAttachment2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachment2.Location = new System.Drawing.Point(61, 370);
            this.btnAttachment2.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachment2.Name = "btnAttachment2";
            this.btnAttachment2.Size = new System.Drawing.Size(47, 28);
            this.btnAttachment2.TabIndex = 16;
            this.btnAttachment2.Text = "...";
            this.btnAttachment2.UseVisualStyleBackColor = true;
            this.btnAttachment2.Click += new System.EventHandler(this.btnAttachment2_Click);
            // 
            // frmExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 455);
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
            this.Controls.Add(this.txbExchangeServer);
            this.Controls.Add(this.lblExchangeServer);
            this.Controls.Add(this.txbSenderPassword);
            this.Controls.Add(this.lblSenderPassword);
            this.Controls.Add(this.txbMailFrom);
            this.Controls.Add(this.lblMailFrom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExchange";
            this.Text = "frmEmail";
            this.Load += new System.EventHandler(this.frmExchange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMailFrom;
        private TextBox txbMailFrom;
        private TextBox txbSenderPassword;
        private Label lblSenderPassword;
        private Label lblExchangeServer;
        private TextBox txbExchangeServer;
        private TextBox txbMailTo;
        private Label lblMailTo;
        private TextBox txbSubject;
        private Label lblSubject;
        private Label lblBody;
        private TextBox txbBody;
        private Button btnEnviar;
        private Button btnCerrar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button btnAttachment1;
        private TextBox txbFilename1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private TextBox txbFilename2;
        private Button btnAttachment2;
    }
}