using System;
using System.Windows.Forms;

namespace ControlsUI
{
    public interface IConfigGrid
    {
        void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e);

        void ApplyTheme(DataGridView grid);

        void SetGridColumnStyleAfterBinding(DataGridView dataGridView);

        void ConfigColumns(DataGridView grid, Type tipo);
    }
}