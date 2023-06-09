﻿using System;
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

        /// <summary>
        /// Poner un contador el el rowheader (columna de la izquierda)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();
            dynamic centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView.RowHeadersWidth, e.RowBounds.Height  /* - sender.rows(e.RowIndex).DividerHeight*/  );
            e.Graphics.DrawString(rowIdx, dataGridView.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}