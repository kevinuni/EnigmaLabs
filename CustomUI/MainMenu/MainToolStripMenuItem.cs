﻿using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public partial class MainToolStripMenuItem : ToolStripMenuItem
    {
        public MainToolStripMenuItem()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private MainMenuitem m_CurrMenuitem;

        public MainMenuitem CurrMenuitem
        {
            get { return m_CurrMenuitem; }
            set { m_CurrMenuitem = value; }
        }
    }
}