using ControlsUI;
using System;
using System.Windows.Forms;
using Enigma.Util;
using Enigma.Util.Crypt;

namespace ControlsUIDemo
{
    public partial class frmCrypto : Form
    {
        public frmCrypto()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public string GenerateUniqueKeyByMachine()
        {
            Fingerprint fp = new Fingerprint();
            return fp.Value();
        }

        private void frmCrypto_Load(object sender, EventArgs e)
        {
            this.txbKey.Text = GenerateUniqueKeyByMachine();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string textToEncrypt = txbTextToEncrypt.Text.Trim();
            string key = txbKey.Text.Trim();
            txbEncryptedText.Text = Crypto.EncryptStringAES(textToEncrypt, key);
        }

        private void lblDecrypt_Click(object sender, EventArgs e)
        {
            string textToDecrypt = txbTextToDecrypt.Text.Trim();
            string key = txbKey.Text;
            txbDecryptedText.Text = Crypto.DecryptStringAES(textToDecrypt, key);
        }
    }
}