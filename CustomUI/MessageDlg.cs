using System.Windows.Forms;

namespace ControlsUI
{
    public static class MessageDlg
    {
        public static DialogResult ShowMessage(string sMensaje, string sTitle, MessageBoxButtons eButtons, MessageBoxIcon eIcons)
        {
            return System.Windows.Forms.MessageBox.Show(sMensaje, sTitle, eButtons, eIcons);
        }

        public static DialogResult ShowMessage(string sMensaje, string sTitle = "")
        {
            return System.Windows.Forms.MessageBox.Show(sMensaje, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(string sMensaje, string sTitle = "")
        {
            return System.Windows.Forms.MessageBox.Show(sMensaje, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string sMensaje, string sTitle = "")
        {
            return System.Windows.Forms.MessageBox.Show(sMensaje, sTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowWarning(string sMensaje, string sTitle = "")
        {
            return System.Windows.Forms.MessageBox.Show(sMensaje, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}