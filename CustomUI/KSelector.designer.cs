using System.Windows.Forms;
namespace ControlsUI
{
    partial class KSelector<T, W>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.cbbCombo = new ComboBox();
            this.btnCancel = new Button();
            this.btnFinder = new Button();
            this.SuspendLayout();
            // 
            // cbbCombo
            // 
            this.cbbCombo.DropDownWidth = 500;
            this.cbbCombo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCombo.FormattingEnabled = true;
            this.cbbCombo.Location = new System.Drawing.Point(50, 0);
            this.cbbCombo.Name = "cbbCombo";
            this.cbbCombo.Size = new System.Drawing.Size(342, 21);
            this.cbbCombo.TabIndex = 32;
            this.cbbCombo.DropDownClosed += new System.EventHandler(this.cbbCombo_DropDownClosed);
            this.cbbCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gbbCtaCteIni_KeyDown);
            this.cbbCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gbbCtaCteIni_MouseClick);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(25, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(21, 21);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCtaCteCancel_Click);
            // 
            // btnFinder
            // 
            this.btnFinder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinder.Location = new System.Drawing.Point(0, 0);
            this.btnFinder.Name = "btnFinder";
            this.btnFinder.Size = new System.Drawing.Size(21, 21);
            this.btnFinder.TabIndex = 33;
            this.btnFinder.TabStop = false;
            this.btnFinder.Click += new System.EventHandler(this.btnFinder_Click);
            // 
            // KSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbCombo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinder);
            this.Name = "KSelector";
            this.Size = new System.Drawing.Size(408, 23);
            this.Load += new System.EventHandler(this.cPersonaGeneric_Load);
            this.ResumeLayout(false);

        }

        private void KSelector_Load(object sender, System.EventArgs e)
        {
            
        }

        #endregion

        private ComboBox cbbCombo;
        private Button btnCancel;
        private Button btnFinder;

    }
}
