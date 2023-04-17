using System;
using System.Windows.Forms;

namespace ControlsUI
{
    public interface IGridConfiguration
    {
        void ApplyTheme(DataGridView grid);

        void SetGridColumnStyleAfterBinding(DataGridView dataGridView);

        void ConfigGrid(DataGridView grid);

        void ConfigChildGrid(DataGridView childGrid, Type childType);
    }
}