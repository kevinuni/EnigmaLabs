using Enigma.ControlsUI;
using System;
using System.Windows.Forms;
using Enigma.Util.Mail;

namespace ControlsUIDemo
{
    public partial class frmSmtpClient : Form
    {
        public frmSmtpClient()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string server = txbServer.Text;
            int port = Convert.ToInt32(nudPort.Value);
            string domain = txbDomain.Text;
            string userName = txbUsername.Text;
            string userPassword = txbUserPassword.Text;
            string mailFrom = txbMailFrom.Text;
            string mailTo = txbMailTo.Text;
            string subject = txbSubject.Text;
            string body = txbBody.Text;

            MailExchange.SendMailSmtp(
                server,
                port,
                domain,
                userName,
                userPassword,
                mailFrom,
                mailTo,
                subject,
                body
                );
        }

        private void frmSmtpClient_Load(object sender, EventArgs e)
        {

        }
    }
}