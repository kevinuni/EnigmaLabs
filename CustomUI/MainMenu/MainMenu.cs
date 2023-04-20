using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public partial class MainMenu : MenuStrip
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void LoadMenu(ArrayList arr_bcMenuitem)
        {
            List<MainMenuitem> list = MainMenuManager.Preprocesar(arr_bcMenuitem);

            this.Items.Clear();

            foreach (MainMenuitem bcMenuitem in list)
            {
                this.Items.Add(MainMenuManager.GeneraToolStripMenuItem(bcMenuitem));
            }
        }
    }
}