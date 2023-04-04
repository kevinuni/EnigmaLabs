using ControlsUI;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Util;

namespace ControlsUIDemo
{
    public partial class frmMailMerge : Form
    {
        public frmMailMerge()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        

        private void btnMerge_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();

            arr.Add(new BE_Data("Bart", "Simpson", new DateTime(1967, 5, 2), 12500.0m));
            arr.Add(new BE_Data("Clarck", "Kent", new DateTime(1961, 3, 11), 20500.0m));
            arr.Add(new BE_Data("John", "Doe", new DateTime(1980, 1, 1), 30000.0m));

            DataTable dt = CollectionManager.ToDataTable(arr);

            MailMerge mailMerge = new MailMerge();
            bool exportar = chkExportar.Checked;
            byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
            mailMerge.Procesar(exportar, true, false, data, dt);
        }

        private void btnFilename_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "doc files (*.doc)|*.txt|All files (*.*)|*.*";
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

        private void frmMailMerge_Load(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.Filter = "pdf files (*.pdf)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}