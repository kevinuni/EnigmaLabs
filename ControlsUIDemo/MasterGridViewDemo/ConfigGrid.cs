using ControlsUI;
using System;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public class CustomConfigGrid : IGridConfiguration
    {
        public void ConfigGrid(DataGridView grid)
        {
            DataGridViewColumnCollection columns = grid.Columns;
            columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
            columns.Add(ColumnFactory.TextColumnStyle("FirstName", "Nombre"));
            columns.Add(ColumnFactory.TextColumnStyle("LastName", "Apellido"));

        }
        public void ConfigChildGrid(DataGridView childGrid, Type childType)
        {
            DataGridViewColumnCollection columns = childGrid.Columns;

            if (childType == typeof(Qualifications))
            {
                //grid.AutoGenerateColumns = true;
                columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score1", "Columna 1"));
                columns.Add(ColumnFactory.IntegerColumnStyle("Score2", "Columna 2"));
            }
            else if (childType == typeof(Course))
            {
                columns.Add(ColumnFactory.IntegerColumnStyle("Credits", "Creditos"));
                columns.Add(ColumnFactory.TextColumnStyle("Subject", "Materia"));
                columns.Add(ColumnFactory.TextColumnStyle("Teacher", "Profesor"));
            }
            else
            {
                throw new Exception("Column not configured");
            }
        }

        
    }
}