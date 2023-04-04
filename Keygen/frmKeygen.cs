using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Keygen
{
    public partial class frmKeygen : Form
    {
        public frmKeygen()
        {
            InitializeComponent();
        }

        private void btnGenKeypair_Click(object sender, EventArgs e)
        {
            var rsa = new RSACryptoServiceProvider();
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);

            //
            // This event handler was created by double-clicking the window in the designer.
            // It runs on the program's startup routine.
            //
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folder = folderBrowserDialog1.SelectedPath;

                File.WriteAllText(folder + "\\public.key", publicKey);
                File.WriteAllText(folder + "\\private.key", privateKey);
            }
        }

        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void kLabel1_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}