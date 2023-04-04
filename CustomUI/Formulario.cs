using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsUI
{
    public class Formulario
    {
        public static DialogResult Mostrar(Form form, object sender, bool modal = false)
        {
            form.ShowInTaskbar = false;

            if (modal || (sender is Form && ((Form)sender).Modal))
            {
                // Si se solicita modal, o si el padre es modal
                // entonces el formulario debe ser modal
                form.MdiParent = null;
                form.StartPosition = FormStartPosition.CenterParent;
                return form.ShowDialog();
            }
            else
            {
                form.MdiParent = (Form)sender;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                return DialogResult.None;
            }
        }
    }
}
