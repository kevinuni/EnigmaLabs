using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Enigma.Util
{
    public static class ExportToExcel
    {
        /// <summary>
        /// Exporta la información de un DataTable a Excel
        /// </summary>
        /// <param name="pDataTable">DataTable de origen</param>
        /// <param name="dgv">DataGridView de origen (solo para tomar los titulos de las columnas y determinar las columnas a mostrar)</param>
        /// <param name="pFullPath_toExport">Ruta a exportar</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        public static void ExportDataTableToExcel(System.Data.DataTable pDataTable, string pFullPath_toExport, string nameSheet, bool allColumns = false)
        {
            string vFileName = Path.GetTempFileName();
            FileSystem.FileOpen(1, vFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

            string sb = string.Empty;

            #region [Cabecera]

            //List<string> listDataproperynames = GetDatapropertynames(dgv);

            foreach (DataColumn dc in pDataTable.Columns)
            {
                // poner de cabecera el nombre de la propiedad
                sb += dc.ColumnName + ControlChars.Tab;
            }

            FileSystem.PrintLine(1, sb);
            #endregion [Cabecera]

            #region[Detalle]
            foreach (DataRow dr in pDataTable.Rows)
            {
                sb = string.Empty;

                foreach (DataColumn dc in pDataTable.Columns)
                {
                    sb = sb + (Information.IsDBNull(dr[dc.ColumnName]) ? string.Empty : FormatCell(dr[dc.ColumnName])) + ControlChars.Tab;
                }
                FileSystem.PrintLine(1, sb);
            }
            #endregion[Detalle]

            FileSystem.FileClose(1);
            TextToExcel(vFileName, pFullPath_toExport, nameSheet);
            File.Delete(vFileName);
        }

        /// <summary>
        /// Limpieza de caracteres de la celda a exportar
        /// </summary>
        /// <param name="cell">Celda del datarow a formatear</param>
        /// <returns>cadena formateada</returns>
        public static string FormatCell(Object cell)
        {
            string TextToParse = Convert.ToString(cell);
            return TextToParse.Replace(",", string.Empty);
        }

        /// <summary>
        /// Exporta un determinado texto en cadena a excel
        /// </summary>
        /// <param name="pFileName">Filename del archivo exportado</param>
        /// <param name="exportPath">Ruta del archivo exportado</param>
        /// <param name="sheetName">nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        public static void TextToExcel(string pFileName, string exportPath, string sheetName)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Microsoft.Office.Interop.Excel._Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.OpenText(pFileName, Missing.Value, 1,
                XlTextParsingType.xlDelimited,
                XlTextQualifier.xlTextQualifierNone,
                Missing.Value, Missing.Value,
                Missing.Value, true,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value);

            Workbook workbook = excelApp.ActiveWorkbook;
            Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
            worksheet.Name = string.IsNullOrWhiteSpace(sheetName) ? "hoja1" : sheetName;

            //formato a la cabecera
            Microsoft.Office.Interop.Excel.Range c1 = worksheet.Cells[1, 1];
            Microsoft.Office.Interop.Excel.Range c2 = worksheet.Cells[worksheet.UsedRange.Rows.Count, worksheet.UsedRange.Columns.Count];
            worksheet.get_Range(c1, c2).AutoFormat(XlRangeAutoFormat.xlRangeAutoFormatClassic1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            string tempPath = Path.GetTempFileName();

            pFileName = tempPath.Replace("tmp", "xls");
            File.Delete(pFileName);

            if (File.Exists(exportPath))
            {
                File.Delete(exportPath);
            }
            excelApp.ActiveWorkbook.SaveAs(exportPath, 1,
                null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

            excelApp.Workbooks.Close();

            Marshal.ReleaseComObject(worksheet);
            worksheet = null;

            Marshal.ReleaseComObject(workbook);
            workbook = null;

            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            excelApp = null;

            GC.Collect();

            Thread.CurrentThread.CurrentCulture = currentCulture;
        }
    }
}