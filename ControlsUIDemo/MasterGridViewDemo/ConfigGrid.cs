using ControlsUI;
using System;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public class ConfigGrid : ConfigGridBase, IConfigGrid
    {
        public void ApplyTheme(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = true;
            dataGridView.AllowUserToDeleteRows = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.MultiSelect = true;
            dataGridView.ReadOnly = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.ShowCellToolTips = false;

            dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Format columnheader
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridView.ColumnHeadersHeight = 32;

            // Format rowheader
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView.RowHeadersDefaultCellStyle = rowHeaderCellStyle;
            dataGridView.TopLeftHeaderCell.Value = "Nro ";
            dataGridView.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.DefaultCellStyle = defaultCellStyle;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridView.Font = columnHeaderCellStyle.Font;
        }

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
            else if (tipo == typeof(Student))
            {
                columns.Add(ColumnFactory.IntegerColumnStyle("Id", "Id"));
                columns.Add(ColumnFactory.TextColumnStyle("FirstName", "FirstName"));
                columns.Add(ColumnFactory.TextColumnStyle("LastName", "LastName"));
            }
            else
            {
                throw new Exception("Column not configured");
            }
        }
    }
}