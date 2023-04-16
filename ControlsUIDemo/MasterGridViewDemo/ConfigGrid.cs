using ControlsUI;
using System;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public class ConfigGrid : ConfigGridBase, IConfigGrid
    {
        public void ConfigColumns(DataGridView grid, Type tipo)
        {
            DataGridViewColumnCollection columns = grid.Columns;

            if (tipo == typeof(Qualifications))
            {
                //grid.AutoGenerateColumns = true;
                columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score1", "Score1"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score2", "Score2"));
            }
            else if (tipo == typeof(Course))
            {
                columns.Add(ColumnFactory.IntegerColumnStyle("Credits", "Credits"));
                columns.Add(ColumnFactory.TextColumnStyle("Subject", "Subject"));
                columns.Add(ColumnFactory.TextColumnStyle("Teacher", "Teacher"));
            }
            else if (tipo == typeof(Score))
            {
                columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
                columns.Add(ColumnFactory.TextColumnStyle("Score1", "Score1"));
                columns.Add(ColumnFactory.TextColumnStyle("Score2", "Score2"));
            }
            else
            {
                throw new Exception("Column not configured");
            }
        }
    }
}