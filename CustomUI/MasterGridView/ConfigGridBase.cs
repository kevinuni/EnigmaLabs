using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlsUI
{
    public class ConfigGridBase
    {
        protected DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        /// <summary>
        /// Cabecera de las grillas
        /// </summary>
        protected DataGridViewCellStyle columnHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        protected DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        /// <summary>
        /// Estilo de las celdas por defecto
        /// </summary>
        protected DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        /// <summary>
        /// Estilo del rowheader
        /// </summary>
        protected DataGridViewCellStyle rowHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        /// <summary>
        /// Fijar el estilo de las columnas en base a su tipo
        /// Importante: Invocar después de llenar las columnas
        /// </summary>
        /// <param name="dataGridView"></param>
        public void SetGridColumnStyleAfterBinding(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.ValueType == null)
                {
                    //cCol.DefaultCellStyle = dateCellStyle;
                }
                else if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle = dateCellStyle;
                }
                else if (column.ValueType == typeof(decimal) || column.ValueType == typeof(double) || column.ValueType == typeof(int))
                {
                    column.DefaultCellStyle = amountCellStyle;
                }
            }
            //dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

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
    }
}