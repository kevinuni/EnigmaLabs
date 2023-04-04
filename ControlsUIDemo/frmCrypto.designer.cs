using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmCrypto
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
            this.btnClose = new Button();
            this.gbbDecrypt = new GroupBox();
            this.lblDecrypt = new Button();
            this.lblTextToDecrypt = new Label();
            this.txbTextToDecrypt = new TextBox();
            this.lblDecryptedText = new Label();
            this.txbDecryptedText = new TextBox();
            this.gbbEncrypt = new GroupBox();
            this.btnEncrypt = new Button();
            this.lblTextToEncrypt = new Label();
            this.txbTextToEncrypt = new TextBox();
            this.lblEcryptedText = new Label();
            this.txbEncryptedText = new TextBox();
            this.txbKey = new TextBox();
            this.lblKey = new Label();
            this.gbbDecrypt.SuspendLayout();
            this.gbbEncrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(393, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbbDecrypt
            // 
            this.gbbDecrypt.Controls.Add(this.lblDecrypt);
            this.gbbDecrypt.Controls.Add(this.lblTextToDecrypt);
            this.gbbDecrypt.Controls.Add(this.txbTextToDecrypt);
            this.gbbDecrypt.Controls.Add(this.lblDecryptedText);
            this.gbbDecrypt.Controls.Add(this.txbDecryptedText);
            this.gbbDecrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbbDecrypt.Location = new System.Drawing.Point(31, 163);
            this.gbbDecrypt.Name = "gbbDecrypt";
            this.gbbDecrypt.Size = new System.Drawing.Size(437, 124);
            this.gbbDecrypt.TabIndex = 11;
            this.gbbDecrypt.TabStop = false;
            this.gbbDecrypt.Text = "Decrypt";
            // 
            // lblDecrypt
            // 
            this.lblDecrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecrypt.Location = new System.Drawing.Point(341, 86);
            this.lblDecrypt.Name = "lblDecrypt";
            this.lblDecrypt.Size = new System.Drawing.Size(75, 23);
            this.lblDecrypt.TabIndex = 8;
            this.lblDecrypt.Text = "Decrypt";
            this.lblDecrypt.UseVisualStyleBackColor = true;
            this.lblDecrypt.Click += new System.EventHandler(this.lblDecrypt_Click);
            // 
            // lblTextToDecrypt
            // 
            this.lblTextToDecrypt.AutoSize = true;
            this.lblTextToDecrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextToDecrypt.Location = new System.Drawing.Point(23, 31);
            this.lblTextToDecrypt.Name = "lblTextToDecrypt";
            this.lblTextToDecrypt.Size = new System.Drawing.Size(95, 13);
            this.lblTextToDecrypt.TabIndex = 4;
            this.lblTextToDecrypt.Text = "Text to Decrypt";
            // 
            // txbTextToDecrypt
            // 
            this.txbTextToDecrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTextToDecrypt.Location = new System.Drawing.Point(122, 28);
            this.txbTextToDecrypt.Name = "txbTextToDecrypt";
            this.txbTextToDecrypt.Size = new System.Drawing.Size(295, 21);
            this.txbTextToDecrypt.TabIndex = 5;
            // 
            // lblDecryptedText
            // 
            this.lblDecryptedText.AutoSize = true;
            this.lblDecryptedText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptedText.Location = new System.Drawing.Point(23, 60);
            this.lblDecryptedText.Name = "lblDecryptedText";
            this.lblDecryptedText.Size = new System.Drawing.Size(92, 13);
            this.lblDecryptedText.TabIndex = 6;
            this.lblDecryptedText.Text = "Encrypted Text";
            // 
            // txbDecryptedText
            // 
            this.txbDecryptedText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDecryptedText.Location = new System.Drawing.Point(121, 57);
            this.txbDecryptedText.Name = "txbDecryptedText";
            this.txbDecryptedText.Size = new System.Drawing.Size(295, 21);
            this.txbDecryptedText.TabIndex = 7;
            // 
            // gbbEncrypt
            // 
            this.gbbEncrypt.Controls.Add(this.btnEncrypt);
            this.gbbEncrypt.Controls.Add(this.lblTextToEncrypt);
            this.gbbEncrypt.Controls.Add(this.txbTextToEncrypt);
            this.gbbEncrypt.Controls.Add(this.lblEcryptedText);
            this.gbbEncrypt.Controls.Add(this.txbEncryptedText);
            this.gbbEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbbEncrypt.Location = new System.Drawing.Point(31, 39);
            this.gbbEncrypt.Name = "gbbEncrypt";
            this.gbbEncrypt.Size = new System.Drawing.Size(437, 118);
            this.gbbEncrypt.TabIndex = 10;
            this.gbbEncrypt.TabStop = false;
            this.gbbEncrypt.Text = "Encrypt";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(342, 85);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblTextToEncrypt
            // 
            this.lblTextToEncrypt.AutoSize = true;
            this.lblTextToEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextToEncrypt.Location = new System.Drawing.Point(22, 29);
            this.lblTextToEncrypt.Name = "lblTextToEncrypt";
            this.lblTextToEncrypt.Size = new System.Drawing.Size(93, 13);
            this.lblTextToEncrypt.TabIndex = 0;
            this.lblTextToEncrypt.Text = "Text to Encrypt";
            // 
            // txbTextToEncrypt
            // 
            this.txbTextToEncrypt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTextToEncrypt.Location = new System.Drawing.Point(121, 26);
            this.txbTextToEncrypt.Name = "txbTextToEncrypt";
            this.txbTextToEncrypt.Size = new System.Drawing.Size(295, 21);
            this.txbTextToEncrypt.TabIndex = 1;
            // 
            // lblEcryptedText
            // 
            this.lblEcryptedText.AutoSize = true;
            this.lblEcryptedText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEcryptedText.Location = new System.Drawing.Point(22, 58);
            this.lblEcryptedText.Name = "lblEcryptedText";
            this.lblEcryptedText.Size = new System.Drawing.Size(92, 13);
            this.lblEcryptedText.TabIndex = 2;
            this.lblEcryptedText.Text = "Encrypted Text";
            // 
            // txbEncryptedText
            // 
            this.txbEncryptedText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEncryptedText.Location = new System.Drawing.Point(120, 55);
            this.txbEncryptedText.Name = "txbEncryptedText";
            this.txbEncryptedText.Size = new System.Drawing.Size(295, 21);
            this.txbEncryptedText.TabIndex = 3;
            // 
            // txbKey
            // 
            this.txbKey.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbKey.Location = new System.Drawing.Point(153, 15);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(295, 21);
            this.txbKey.TabIndex = 9;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(53, 18);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(29, 13);
            this.lblKey.TabIndex = 8;
            this.lblKey.Text = "Key";
            // 
            // frmCrypto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 330);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbbDecrypt);
            this.Controls.Add(this.gbbEncrypt);
            this.Controls.Add(this.txbKey);
            this.Controls.Add(this.lblKey);
            this.Name = "frmCrypto";
            this.Text = "frmCrypto";
            this.Load += new System.EventHandler(this.frmCrypto_Load);
            this.gbbDecrypt.ResumeLayout(false);
            this.gbbDecrypt.PerformLayout();
            this.gbbEncrypt.ResumeLayout(false);
            this.gbbEncrypt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTextToEncrypt;
        private TextBox txbTextToEncrypt;
        private Label lblEcryptedText;
        private TextBox txbEncryptedText;
        private TextBox txbDecryptedText;
        private Label lblDecryptedText;
        private TextBox txbTextToDecrypt;
        private Label lblTextToDecrypt;
        private TextBox txbKey;
        private Label lblKey;
        private GroupBox gbbEncrypt;
        private Button btnEncrypt;
        private GroupBox gbbDecrypt;
        private Button lblDecrypt;
        private Button btnClose;
    }
}