using System;
using System.Windows.Forms;

namespace ControlsUI
{
    public interface IGridConfiguration
    {
        void ConfigGrid(DataGridView grid);

        void ConfigChildGrid(DataGridView childGrid, Type childType);
    }
}