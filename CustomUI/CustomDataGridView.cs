using System.Drawing;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    /// <summary>
    /// La grilla tiene el comportamiento de que al presionar ENTER en una celda, se pasa a la siguiente celda a la DERECHA
    /// </summary>
    [ToolboxBitmap(typeof(DataGridView))]
    public class CustomDataGridView : DataGridView
    {
        [System.Security.Permissions.UIPermission(
            System.Security.Permissions.SecurityAction.LinkDemand,
            Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Extract the key code from the key value.
            Keys key = (keyData & Keys.KeyCode);

            // Handle the ENTER key as if it were a RIGHT ARROW key.
            if (key == Keys.Enter)
            {
                if (this.SelectedCells.Count > 0 && this.SelectedCells[0].ColumnIndex != this.Columns.Count - 1)
                {
                    return this.ProcessRightKey(keyData);
                }
                else if (this.SelectedCells.Count > 0 && this.SelectedCells[0].ColumnIndex == this.Columns.Count - 1)
                {
                    return this.ProcessTabKey(keyData);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        [System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.LinkDemand, Flags =
            System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            // Handle the ENTER key as if it were a RIGHT ARROW key.
            if (e.KeyCode == Keys.Enter)
            {
                if (this.SelectedCells.Count > 0 && this.SelectedCells[0].ColumnIndex != this.Columns.Count - 1)
                {
                    return this.ProcessRightKey(e.KeyData);
                }
                else if (this.SelectedCells.Count > 0 && this.SelectedCells[0].ColumnIndex == this.Columns.Count - 1)
                {
                    return this.ProcessTabKey(e.KeyData);
                }
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
}