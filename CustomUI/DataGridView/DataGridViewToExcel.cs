using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Util;

namespace ControlsUI
{
    public class DataGridViewToExcel
    {
        /// <summary>
        /// Exporta la información de un dataGridView a Excel
        /// </summary>
        /// <param name="dataGridView">DataGridView de origen</param>
        /// <param name="pFullPath_toExport">Ruta del archivo exportado</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        public static void ExportDataGridViewToExcel(DataGridView dataGridView, string pFullPath_toExport, string nameSheet, bool allcolumns = false)
        {
            Object obj = dataGridView.DataSource;
            DataTable dt = new DataTable();

            //Obtener un datatable del datagridview
            if (dataGridView.DataSource is DataSet)
            {
                if (((System.Data.DataSet)dataGridView.DataSource).Tables.Count > 0)
                    dt = ((System.Data.DataSet)dataGridView.DataSource).Tables[0];
                else
                    dt = new DataTable();
            }
            else if (dataGridView.DataSource is System.Data.DataTable)
            {
                dt = (System.Data.DataTable)dataGridView.DataSource;
            }
            else if (dataGridView.DataSource is IEnumerable)
            {
                IEnumerable list = (IEnumerable)dataGridView.DataSource;
                dt = CollectionManager.ToDataTable(list);
            }
            DataTable2Excel(dt, dataGridView, pFullPath_toExport, nameSheet, allcolumns);
        }

        private static List<string> GetDatapropertynames(DataGridView dgv)
        {
            List<string> listOfPropertyname = new List<string>();

            if (dgv != null)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    listOfPropertyname.Add(col.DataPropertyName);
                }
            }

            return listOfPropertyname;
        }

        /// <summary>
        /// Exporta la información de un DataTable a Excel
        /// </summary>
        /// <param name="pDataTable">DataTable de origen</param>
        /// <param name="dgv">DataGridView de origen (solo para tomar los titulos de las columnas y determinar las columnas a mostrar)</param>
        /// <param name="pFullPath_toExport">Ruta a exportar</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        private static void DataTable2Excel(System.Data.DataTable pDataTable, DataGridView dgv, string pFullPath_toExport, string nameSheet, bool allColumns = false)
        {
            string vFileName = Path.GetTempFileName();
            FileSystem.FileOpen(1, vFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

            string sb = string.Empty;

            #region [Cabecera]
            // poner primero las columnas de la grilla
            foreach (DataGridViewColumn gridColumn in dgv.Columns)
            {
                System.Windows.Forms.Application.DoEvents();
                // poner de cabecera la misma cabecera que la grilla
                sb += gridColumn.HeaderText + ControlChars.Tab;
            }

            List<string> listDataproperynames = GetDatapropertynames(dgv);

            // poner las columnas del datatable que no se encuentran en la grilla
            if (allColumns)
            {
                foreach (DataColumn dc in pDataTable.Columns)
                {
                    System.Windows.Forms.Application.DoEvents();
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
            foreach (DataRow dr in pDataTable.Rows)
            {
                System.Windows.Forms.Application.DoEvents();
                sb = string.Empty;

                // poner primero las columnas de la grilla (en caso exista)
                foreach (DataGridViewColumn gridColumn in dgv.Columns)
                {
                    System.Windows.Forms.Application.DoEvents();
                    sb = sb + (Information.IsDBNull(dr[gridColumn.DataPropertyName]) ? string.Empty : ExportToExcel.FormatCell(dr[gridColumn.DataPropertyName])) + ControlChars.Tab;
                }

                // poner las columnas del datatable que no se encuentran en la grilla
                if (allColumns)
                {
                    foreach (DataColumn dc in pDataTable.Columns)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        if (listDataproperynames.Contains(dc.ColumnName) == false)
                        {
                            System.Windows.Forms.Application.DoEvents();

                            sb = sb + (Information.IsDBNull(dr[dc.ColumnName]) ? string.Empty : ExportToExcel.FormatCell(dr[dc.ColumnName])) + ControlChars.Tab;
                        }
                    }
                }
                FileSystem.PrintLine(1, sb);
            }
            #endregion[Detalle]

            FileSystem.FileClose(1);
            ExportToExcel.TextToExcel(vFileName, pFullPath_toExport, nameSheet);
            File.Delete(vFileName);
        }
    }
}