using ControlsUI;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Enigma.Util;

namespace ControlsUIDemo
{
    public partial class frmZipFile : Form
    {
        public frmZipFile()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void btnFilename_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilenameIn.Text = openFileDialog1.FileName;
            }
            else
            {
                txbFilenameIn.Text = string.Empty;
            }
        }

        private void btnSecure_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filenameIn = openFileDialog1.FileName;
                string password = txbPassword.Text;

                Hashtable hsDataIn = new Hashtable();
                //archivo 1
                FileInfo fi = new FileInfo(filenameIn);
                byte[] dataIn = File.ReadAllBytes(filenameIn);
                hsDataIn.Add(filenameIn, dataIn);

                //archivo 2
                hsDataIn.Add("copy_of_" + filenameIn, filenameIn);

                byte[] dataOut = ZipManager.ZipToByteArray(hsDataIn, password);

                string filenameOut = saveFileDialog1.FileName;

                File.WriteAllBytes(filenameOut, dataOut);

                MessageBox.Show("Se ha comprimido el documento", "Comprimir");
            }
        }

        private void frmZipFile_Load(object sender, EventArgs e)
        {
        }
    }
}