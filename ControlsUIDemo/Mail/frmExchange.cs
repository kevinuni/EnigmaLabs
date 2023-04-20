using Enigma.ControlsUI;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Enigma.Util.Mail;

namespace ControlsUIDemo
{
    public partial class frmExchange : Form
    {
        public frmExchange()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Hashtable attachment = new Hashtable();

            try
            {
                byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
                if (data != null)
                {
                    FileInfo fi = new FileInfo(openFileDialog1.FileName);
                    attachment.Add(fi.Name, data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            FileInfo fi2 = new FileInfo(openFileDialog2.FileName);

            if (txbFilename2.Text != string.Empty)
            {
                attachment.Add(fi2.Name, openFileDialog2.FileName);
            }

            string exchangeServer = txbExchangeServer.Text;
            string mailFrom = txbMailFrom.Text;
            string senderPassword = txbSenderPassword.Text;
            string mailTo = txbMailTo.Text;
            string subject = txbSubject.Text;
            string body = txbBody.Text;

            MailExchange.SendMailExchange(
                exchangeServer,
                mailFrom,
                senderPassword,
                mailTo,
                subject,
                body,
                attachment
                );

            MessageBox.Show("Se ha enviado el email", "Prueba de email");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilename1.Text = openFileDialog1.FileName;
            }
            else
            {
                txbFilename1.Text = string.Empty;
            }
        }

        private void btnAttachment2_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txbFilename2.Text = openFileDialog2.FileName;
            }
            else
            {
                txbFilename2.Text = string.Empty;
            }
        }

        private void frmExchange_Load(object sender, EventArgs e)
        {

        }
    }
}