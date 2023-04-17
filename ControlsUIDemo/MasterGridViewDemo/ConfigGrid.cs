using ControlsUI;
using System;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public class ConfigGrid : ConfigGridBase, IGridConfiguration
    {
        public void ConfigChildGrid(DataGridView childGrid, Type childType)
        {
            DataGridViewColumnCollection columns = childGrid.Columns;

            if (childType == typeof(Qualifications))
            {
                //grid.AutoGenerateColumns = true;
                columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score1", "Score1"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score2", "Score2"));
            }
            else if (childType == typeof(Course))
            {
                columns.Add(ColumnFactory.IntegerColumnStyle("Credits", "Credits"));
                columns.Add(ColumnFactory.TextColumnStyle("Subject", "Subject"));
                columns.Add(ColumnFactory.TextColumnStyle("Teacher", "Teacher"));
            }
            else
            {
                throw new Exception("Column not configured");
            }
        }

        void IGridConfiguration.ConfigGrid(DataGridView grid)
        {
            DataGridViewColumnCollection columns = grid.Columns;
            columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
            columns.Add(ColumnFactory.TextColumnStyle("FirstName", "FirstName"));
            columns.Add(ColumnFactory.TextColumnStyle("LastName", "LastName"));
        }
    }
}