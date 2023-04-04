using System.Windows.Forms;
namespace ControlsUI
{
    partial class frmFinder<T,W>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinder<T,W>));
            this.gbbUnidad = new GroupBox();
            this.datagridOfT = new DataGridView();
            this.tlsFind = new ToolStrip();
            this.tbtnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new Button();
            this.btnSelect = new Button();
            this.gbbUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridOfT)).BeginInit();
            this.tlsFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbbUnidad
            // 
            this.gbbUnidad.Controls.Add(this.datagridOfT);
            this.gbbUnidad.Controls.Add(this.tlsFind);
            this.gbbUnidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbbUnidad.Location = new System.Drawing.Point(21, 12);
            this.gbbUnidad.Name = "gbbUnidad";
            this.gbbUnidad.Size = new System.Drawing.Size(663, 345);
            this.gbbUnidad.TabIndex = 1;
            this.gbbUnidad.TabStop = false;
            this.gbbUnidad.Text = "Unidad";
            // 
            // datagridOfT
            // 
            this.datagridOfT.AllowUserToResizeRows = false;
            this.datagridOfT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridOfT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridOfT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridOfT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridOfT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridOfT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridOfT.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridOfT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridOfT.EnableHeadersVisualStyles = false;
            this.datagridOfT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.datagridOfT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridOfT.Location = new System.Drawing.Point(3, 42);
            this.datagridOfT.Name = "datagridOfT";
            this.datagridOfT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridOfT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagridOfT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridOfT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridOfT.Size = new System.Drawing.Size(657, 300);
            this.datagridOfT.TabIndex = 1;
            // 
            // tlsFind
            // 
            this.tlsFind.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnActualizar});
            this.tlsFind.Location = new System.Drawing.Point(3, 17);
            this.tlsFind.Name = "tlsFind";
            this.tlsFind.Size = new System.Drawing.Size(657, 25);
            this.tlsFind.TabIndex = 0;
            this.tlsFind.Text = "kToolStrip1";
            // 
            // tbtnActualizar
            //             
            this.tbtnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnActualizar.Name = "tbtnActualizar";
            this.tbtnActualizar.Size = new System.Drawing.Size(83, 22);
            this.tbtnActualizar.Text = "Actualizar";
            this.tbtnActualizar.Click += new System.EventHandler(this.tbtnActualizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = null;
            this.btnCerrar.Location = new System.Drawing.Point(606, 366);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = null;
            this.btnSelect.Location = new System.Drawing.Point(516, 366);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 401);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gbbUnidad);
            this.Name = "frmFinder";
            this.Text = "frmFindEntity";
            this.Load += new System.EventHandler(this.frmFindEntity_Load);
            this.gbbUnidad.ResumeLayout(false);
            this.gbbUnidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridOfT)).EndInit();
            this.tlsFind.ResumeLayout(false);
            this.tlsFind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbbUnidad;
        private DataGridView datagridOfT;
        private ToolStrip tlsFind;
        private System.Windows.Forms.ToolStripButton tbtnActualizar;
        private Button btnCerrar;
        private Button btnSelect;

    }
}