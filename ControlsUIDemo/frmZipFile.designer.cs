using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmZipFile
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
            this.btnFilename = new Button();
            this.txbFilenameIn = new TextBox();
            this.lblFilename = new Label();
            this.btnCerrar = new Button();
            this.btnSecure = new Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblPassword = new Label();
            this.txbPassword = new TextBox();
            this.SuspendLayout();
            // 
            // btnFilename
            // 
            this.btnFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilename.Location = new System.Drawing.Point(599, 10);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(33, 23);
            this.btnFilename.TabIndex = 5;
            this.btnFilename.Text = "...";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // txbFilenameIn
            // 
            this.txbFilenameIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilenameIn.Location = new System.Drawing.Point(148, 12);
            this.txbFilenameIn.Name = "txbFilenameIn";
            this.txbFilenameIn.Size = new System.Drawing.Size(445, 21);
            this.txbFilenameIn.TabIndex = 4;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(40, 15);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(58, 13);
            this.lblFilename.TabIndex = 3;
            this.lblFilename.Text = "Filename";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(556, 48);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnSecure
            // 
            this.btnSecure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecure.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecure.Location = new System.Drawing.Point(471, 48);
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Size = new System.Drawing.Size(75, 23);
            this.btnSecure.TabIndex = 9;
            this.btnSecure.Text = "Zip";
            this.btnSecure.UseVisualStyleBackColor = true;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(40, 43);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(148, 40);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(201, 21);
            this.txbPassword.TabIndex = 11;
            // 
            // frmZipFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 83);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSecure);
            this.Controls.Add(this.btnFilename);
            this.Controls.Add(this.txbFilenameIn);
            this.Controls.Add(this.lblFilename);
            this.Name = "frmZipFile";
            this.Text = "frmZipcs";
            this.Load += new System.EventHandler(this.frmZipFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFilename;
        private TextBox txbFilenameIn;
        private Label lblFilename;
        private Button btnCerrar;
        private Button btnSecure;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Label lblPassword;
        private TextBox txbPassword;
    }
}