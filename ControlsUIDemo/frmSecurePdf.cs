using ControlsUI;
using System;
using System.IO;
using System.Windows.Forms;
using Enigma.Util;

namespace ControlsUIDemo
{
    public partial class frmSecurePdf : Form
    {
        public frmSecurePdf()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void btnSecure_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filenameIn = openFileDialog1.FileName;
                FileStream myStreamIn = new FileStream(filenameIn, FileMode.Open, FileAccess.Read);

                string userPassword = txbUserPassword.Text;
                string ownerPassword = txbOwnerPassword.Text;

                byte[] data = PdfManager.SecurePdf(myStreamIn, userPassword, ownerPassword);
                myStreamIn.Close();

                string filename = saveFileDialog1.FileName;

                File.WriteAllBytes(filename, data);

                MessageBox.Show("Se ha protegido el documento", "Proteger PDF");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnFilename_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilename.Text = openFileDialog1.FileName;
            }
            else
            {
                txbFilename.Text = string.Empty;
            }
        }

        private void frmSecurePdf_Load(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
        }
    }
}