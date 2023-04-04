using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmSecurePdf
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCerrar = new Button();
            this.lblOwnerPassword = new Label();
            this.txbOwnerPassword = new TextBox();
            this.lblUserPassword = new Label();
            this.txbUserPassword = new TextBox();
            this.btnSecure = new Button();
            this.btnFilename = new Button();
            this.txbFilename = new TextBox();
            this.lblFilename = new Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(551, 91);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblOwnerPassword
            // 
            this.lblOwnerPassword.AutoSize = true;
            this.lblOwnerPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerPassword.Location = new System.Drawing.Point(27, 74);
            this.lblOwnerPassword.Name = "lblOwnerPassword";
            this.lblOwnerPassword.Size = new System.Drawing.Size(102, 13);
            this.lblOwnerPassword.TabIndex = 7;
            this.lblOwnerPassword.Text = "Owner Password";
            // 
            // txbOwnerPassword
            // 
            this.txbOwnerPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOwnerPassword.Location = new System.Drawing.Point(135, 71);
            this.txbOwnerPassword.Name = "txbOwnerPassword";
            this.txbOwnerPassword.Size = new System.Drawing.Size(201, 21);
            this.txbOwnerPassword.TabIndex = 6;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPassword.Location = new System.Drawing.Point(27, 47);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(91, 13);
            this.lblUserPassword.TabIndex = 5;
            this.lblUserPassword.Text = "User Password";
            // 
            // txbUserPassword
            // 
            this.txbUserPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserPassword.Location = new System.Drawing.Point(135, 44);
            this.txbUserPassword.Name = "txbUserPassword";
            this.txbUserPassword.Size = new System.Drawing.Size(201, 21);
            this.txbUserPassword.TabIndex = 4;
            // 
            // btnSecure
            // 
            this.btnSecure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecure.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecure.Location = new System.Drawing.Point(466, 91);
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Size = new System.Drawing.Size(75, 23);
            this.btnSecure.TabIndex = 3;
            this.btnSecure.Text = "Secure";
            this.btnSecure.UseVisualStyleBackColor = true;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            // 
            // btnFilename
            // 
            this.btnFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilename.Location = new System.Drawing.Point(586, 15);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(33, 23);
            this.btnFilename.TabIndex = 2;
            this.btnFilename.Text = "...";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // txbFilename
            // 
            this.txbFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename.Location = new System.Drawing.Point(135, 17);
            this.txbFilename.Name = "txbFilename";
            this.txbFilename.Size = new System.Drawing.Size(445, 21);
            this.txbFilename.TabIndex = 1;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(27, 20);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(58, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "Filename";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmSecurePdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 125);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblOwnerPassword);
            this.Controls.Add(this.txbOwnerPassword);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.txbUserPassword);
            this.Controls.Add(this.btnSecure);
            this.Controls.Add(this.btnFilename);
            this.Controls.Add(this.txbFilename);
            this.Controls.Add(this.lblFilename);
            this.Name = "frmSecurePdf";
            this.Text = "frmSecurePdf";
            this.Load += new System.EventHandler(this.frmSecurePdf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFilename;
        private TextBox txbFilename;
        private Button btnFilename;
        private Button btnSecure;
        private TextBox txbUserPassword;
        private Label lblUserPassword;
        private Label lblOwnerPassword;
        private TextBox txbOwnerPassword;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Button btnCerrar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}