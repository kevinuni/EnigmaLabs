using System.Windows.Forms;
namespace Keygen
{
    partial class frmKeygen
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGenKeypair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::Keygen.Properties.Resources.exit;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(184, 14);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGenKeypair
            // 
            this.btnGenKeypair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenKeypair.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenKeypair.Image = global::Keygen.Properties.Resources.llaves;
            this.btnGenKeypair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenKeypair.Location = new System.Drawing.Point(12, 14);
            this.btnGenKeypair.Name = "btnGenKeypair";
            this.btnGenKeypair.Size = new System.Drawing.Size(135, 23);
            this.btnGenKeypair.TabIndex = 2;
            this.btnGenKeypair.Text = "Generate keyPair";
            this.btnGenKeypair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenKeypair.UseVisualStyleBackColor = true;
            this.btnGenKeypair.Click += new System.EventHandler(this.btnGenKeypair_Click);
            // 
            // frmKeygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 49);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenKeypair);
            this.Name = "frmKeygen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnGenKeypair;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button btnSalir;
    }
}

