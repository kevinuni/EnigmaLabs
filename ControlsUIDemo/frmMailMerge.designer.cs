using System.Windows.Forms;
namespace ControlsUIDemo
{
    partial class frmMailMerge
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
            this.btnMerge = new Button();
            this.btnFilename = new Button();
            this.txbFilename = new TextBox();
            this.lblFilename = new Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCerrar = new Button();
            this.chkExportar = new CheckBox();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(453, 48);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnFilename
            // 
            this.btnFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilename.Location = new System.Drawing.Point(585, 10);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(33, 23);
            this.btnFilename.TabIndex = 5;
            this.btnFilename.Text = "...";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // txbFilename
            // 
            this.txbFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFilename.Location = new System.Drawing.Point(134, 12);
            this.txbFilename.Name = "txbFilename";
            this.txbFilename.Size = new System.Drawing.Size(445, 21);
            this.txbFilename.TabIndex = 4;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(26, 15);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(58, 13);
            this.lblFilename.TabIndex = 3;
            this.lblFilename.Text = "Filename";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(536, 46);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chkExportar
            // 
            this.chkExportar.AutoSize = true;
            this.chkExportar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExportar.Location = new System.Drawing.Point(39, 48);
            this.chkExportar.Name = "chkExportar";
            this.chkExportar.Size = new System.Drawing.Size(75, 17);
            this.chkExportar.TabIndex = 10;
            this.chkExportar.Text = "Exportar";
            this.chkExportar.UseVisualStyleBackColor = true;
            // 
            // frmMailMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 81);
            this.Controls.Add(this.chkExportar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFilename);
            this.Controls.Add(this.txbFilename);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnMerge);
            this.Name = "frmMailMerge";
            this.Text = "frmMailMerge";
            this.Load += new System.EventHandler(this.frmMailMerge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnMerge;
        private Button btnFilename;
        private TextBox txbFilename;
        private Label lblFilename;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button btnCerrar;
        private CheckBox chkExportar;
    }
}