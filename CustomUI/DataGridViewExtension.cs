using Enigma.Util;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public static class DataGridViewExtension
    {
        private static DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        private static DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight
        };

        /// <summary>
        /// Cabecera de las grillas
        /// </summary>
        private static DataGridViewCellStyle columnHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        /// <summary>
        /// Estilo de las celdas por defecto
        /// </summary>
        private static DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
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
        private static DataGridViewCellStyle rowHeaderCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        public static void SetDefaultCellStyle(this DataGridView dataGridView)
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

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public static void ApplyTheme(this DataGridView dgw)
        {
            dgw.AllowUserToAddRows = true;
            dgw.AllowUserToDeleteRows = true;
            dgw.AllowUserToResizeRows = false;
            dgw.AllowUserToResizeColumns = true;
            dgw.AutoGenerateColumns = false;
            dgw.Dock = DockStyle.Fill;
            dgw.MultiSelect = true;
            dgw.ReadOnly = false;
            dgw.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgw.ShowCellToolTips = false;

            dgw.BackgroundColor = SystemColors.Window;
            dgw.BorderStyle = BorderStyle.None;

            // Format columnheader
            dgw.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgw.ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;
            dgw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridView.ColumnHeadersHeight = 32;

            // Format rowheader
            dgw.RowHeadersVisible = true;
            dgw.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgw.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgw.RowHeadersDefaultCellStyle = rowHeaderCellStyle;
            dgw.TopLeftHeaderCell.Value = "Nro ";
            dgw.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgw.DefaultCellStyle = defaultCellStyle;
            dgw.EnableHeadersVisualStyles = false;
            dgw.GridColor = SystemColors.GradientInactiveCaption;
            dgw.Font = columnHeaderCellStyle.Font;
        }

        #region [Export To Excel]

        /// <summary>
        /// Exporta la información de un dataGridView a Excel
        /// </summary>
        /// <param name="dgv">DataGridView de origen</param>
        /// <param name="pFullPath_toExport">Ruta del archivo exportado</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        public static void ExportDataGridViewToExcel(this DataGridView dgv, string pFullPath_toExport, string nameSheet, bool allcolumns = false)
        {
            Object obj = dgv.DataSource;
            DataTable dt = new DataTable();

            //Obtener un datatable del datagridview
            if (dgv.DataSource is DataSet)
            {
                if (((DataSet)dgv.DataSource).Tables.Count > 0)
                    dt = ((DataSet)dgv.DataSource).Tables[0];
                else
                    dt = new DataTable();
            }
            else if (dgv.DataSource is DataTable)
            {
                dt = (DataTable)dgv.DataSource;
            }
            else if (dgv.DataSource is System.Collections.IEnumerable)
            {
                System.Collections.IEnumerable list = (System.Collections.IEnumerable)dgv.DataSource;
                dt = CollectionManager.ToDataTable(list);
            }
            DataTable2Excel(dgv, dt, pFullPath_toExport, nameSheet, allcolumns);
        }

        /// <summary>
        /// Exporta la información de un DataTable a Excel
        /// </summary>
        /// <param name="dt">DataTable de origen</param>
        /// <param name="dgv">DataGridView de origen (solo para tomar los titulos de las columnas y determinar las columnas a mostrar)</param>
        /// <param name="path">Ruta a exportar</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        private static void DataTable2Excel(this DataGridView dgv, DataTable dt, string path, string nameSheet, bool allColumns = false)
        {
            string vFileName = Path.GetTempFileName();
            FileSystem.FileOpen(1, vFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

            string sb = string.Empty;

            #region [Cabecera]
            // poner primero las columnas de la grilla
            foreach (DataGridViewColumn gridColumn in dgv.Columns)
            {
                Application.DoEvents();

                // poner de cabecera la misma cabecera que la grilla
                sb += gridColumn.HeaderText + ControlChars.Tab;
            }

            //Obtener propiedades
            List<string> listDataproperynames = new List<string>();

            if (dgv != null)
            {
                foreach (DataGridViewColumn gridColumn in dgv.Columns)
                {
                    listDataproperynames.Add(gridColumn.DataPropertyName);
                }
            }

            // poner las columnas del datatable que no se encuentran en la grilla
            if (allColumns)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    Application.DoEvents();
                    if (listDataproperynames.Contains(dc.ColumnName) == false)
                    {
                        // poner de cabecera el nombre de la propiedad
                        sb += dc.ColumnName + ControlChars.Tab;
                    }
                }
            }
            FileSystem.PrintLine(1, sb);
            #endregion [Cabecera]

            #region[Detalle]
            foreach (DataRow dr in dt.Rows)
            {
                Application.DoEvents();
                sb = string.Empty;

                // poner primero las columnas de la grilla (en caso exista)
                foreach (DataGridViewColumn gridColumn in dgv.Columns)
                {
                    Application.DoEvents();
                    sb = sb + (Information.IsDBNull(dr[gridColumn.DataPropertyName]) ? string.Empty : ExportToExcel.FormatCell(dr[gridColumn.DataPropertyName])) + ControlChars.Tab;
                }

                // poner las columnas del datatable que no se encuentran en la grilla
                if (allColumns)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Application.DoEvents();
                        if (listDataproperynames.Contains(dc.ColumnName) == false)
                        {
                            Application.DoEvents();
                            sb = sb + (Information.IsDBNull(dr[dc.ColumnName]) ? string.Empty : ExportToExcel.FormatCell(dr[dc.ColumnName])) + ControlChars.Tab;
                        }
                    }
                }
                FileSystem.PrintLine(1, sb);
            }
            #endregion [Export To Excel]

            FileSystem.FileClose(1);
            ExportToExcel.TextToExcel(vFileName, path, nameSheet);
            File.Delete(vFileName);
        }

        #endregion [Export To Excel]
    }
}