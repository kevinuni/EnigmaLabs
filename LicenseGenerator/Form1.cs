using Newtonsoft.Json;
using Rhino.Licensing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LicenseGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenlicense_Click(object sender, EventArgs e)
        {
            DateTime expirationDate = dtpExpiration.Value;
            Guid id = Guid.NewGuid();
            string Name = txbName.Text;

            LicenseType licenseType;
            switch (cbbLicenseType.SelectedItem.ToString())
            {
                case Constantes.LICENSETYPE_NONE:
                    licenseType = LicenseType.None;
                    break;

                case Constantes.LICENSETYPE_TRIAL:
                    licenseType = LicenseType.Trial;
                    break;

                case Constantes.LICENSETYPE_STANDARD:
                    licenseType = LicenseType.Standard;
                    break;

                case Constantes.LICENSETYPE_PERSONAL:
                    licenseType = LicenseType.Personal;
                    break;

                case Constantes.LICENSETYPE_FLOATING:
                    licenseType = LicenseType.Floating;
                    break;

                case Constantes.LICENSETYPE_SUBSCRIPTION:
                    licenseType = LicenseType.Subscription;
                    break;

                default:
                    licenseType = LicenseType.None;
                    break;
            }

            dynamic options;

            options = JsonConvert.DeserializeObject<IDictionary<string, string>>(txbIdentificador.Text);

            //Generación de la licencia
            var privateKey = Properties.Settings.Default.PRIVATE_KEY;

            var generator = new Rhino.Licensing.LicenseGenerator(privateKey);

            string license = generator.Generate(Name, id, expirationDate, options, licenseType);

            txbLicense.Text = license;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Guardar Licencia";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileDownloadName = String.Format("{0}.{1}", "licencia", "xml");
                string decodedLicense = txbLicense.Text;
                byte[] renderedBytes = Encoding.ASCII.GetBytes(decodedLicense);

                using (MemoryStream ms = new MemoryStream(renderedBytes))
                {
                    renderedBytes = ms.ToArray();
                    File.WriteAllBytes(saveFileDialog1.FileName, renderedBytes);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}