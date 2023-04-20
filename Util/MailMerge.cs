using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace Enigma.Util
{
    public class MailMerge
    {
        #region [Privados]

        private string m_PlantillaDocPath;
        private string m_CsvPath;
        private string m_SchemaIniPath;
        private string m_CorrespondenciaPdfPath;
        private bool m_Exporta;
        private bool m_GeneraPdf;

        /// <summary>
        /// Indica si se debe dejar abierto Microsoft Word despues de la generación de cartas.
        /// </summary>
        private bool m_CerrarAplicacion;

        #endregion [Privados]

        #region [Publicos]

        public string PlantillaDocPath
        {
            get { return m_PlantillaDocPath; }
        }

        public string CorrespondenciaPdfPath
        {
            get { return m_CorrespondenciaPdfPath; }
        }

        #endregion [Publicos]

        #region [Constructor]

        public MailMerge()
        {
            m_PlantillaDocPath = string.Empty;
            m_CorrespondenciaPdfPath = string.Empty;
            m_CsvPath = string.Empty;
            m_SchemaIniPath = string.Empty;
            m_CerrarAplicacion = true;
            m_Exporta = false;
            m_GeneraPdf = false;
        }

        #endregion [Constructor]

        #region [Metodos]

        /// <summary>
        /// Procesar la carta
        /// </summary>
        /// <param name="exporta">Dejar una copia de la carta en d://</param>
        /// <param name="cerrarAplicacion">Cerrar la aplicación al finalizar</param>
        /// <param name="codcarta">Llave primaria de la carta</param>
        /// <param name="sqlCommand">SqlCommand de la carta</param>
        public void Procesar(bool exporta, bool generaPdf, bool cerrarAplicacion, byte[] data, System.Data.DataTable dt)
        {
            m_Exporta = exporta;
            m_GeneraPdf = generaPdf;
            m_CerrarAplicacion = cerrarAplicacion;
            FijarRutaArchivos();
            //genera archivo plantilla
            File.WriteAllBytes(m_PlantillaDocPath, data);
            ProcesaCorrespondencia(dt);
            EliminaTemporales();
        }

        /// <summary>
        /// Fija la carpeta en donde se guardarán los archivos de datos, plantilla y schema
        /// </summary>
        private void FijarRutaArchivos()
        {
            if (m_Exporta)
            {
                m_PlantillaDocPath = @"d:\data.doc";
                m_SchemaIniPath = @"d:\schema.ini";
                m_CsvPath = @"d:\data.txt";
                m_CorrespondenciaPdfPath = @"d:\data.pdf";
            }
            else
            {
                m_PlantillaDocPath = Path.GetTempPath() + Path.GetRandomFileName() + ".doc";
                m_SchemaIniPath = Path.GetTempPath() + "schema.ini";
                m_CsvPath = Path.GetTempPath() + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".txt";
                m_CorrespondenciaPdfPath = Path.GetTempPath() + Path.GetRandomFileName() + ".pdf";
            }
        }

        private void ProcesaCorrespondencia(System.Data.DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new Exception("La consulta no devolvió datos");
            }

            //generacion del CSV a partir del sqlquery

            #region [Generacion de datos]

            bool cabecera = true;

            StreamWriter sw = new StreamWriter(m_CsvPath, false, Encoding.UTF8);
            string buffer = string.Empty;
            char separador = '|';
            foreach (DataRow dr in dt.Rows)
            {
                if (cabecera == true)
                {
                    buffer = string.Empty;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        buffer += dc.Caption.Trim().Replace(separador, ' ') + separador;
                    }
                    buffer = buffer.TrimEnd(separador);
                    sw.WriteLine(buffer);
                    cabecera = false;
                }

                buffer = string.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dr[dc.Ordinal].ToString().Replace(separador, ' ').Trim() != string.Empty)
                    {
                        buffer += dr[dc.Ordinal].ToString().Replace(separador, ' ').Trim() + separador;
                    }
                    else
                    {
                        buffer += " " + separador;
                    }
                }
                buffer = buffer.TrimEnd(separador);
                sw.WriteLine(buffer);
            }
            sw.Flush();
            sw.Close();

            #endregion [Generacion de datos]

            #region [Schema]

            StreamWriter swSchema = new StreamWriter(m_SchemaIniPath, false);
            swSchema.WriteLine("[" + m_CsvPath + "]");

            swSchema.WriteLine("ColNameHeader=True");
            swSchema.WriteLine("Format=CSVDelimited");
            //swSchema.WriteLine("Format=Delimited(,)");
            swSchema.WriteLine("MaxScanRows=25");
            swSchema.WriteLine("CharacterSet=65001");
            swSchema.Flush();
            swSchema.Close();

            #endregion [Schema]

            #region [MailMerge]

            //Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.DefaultTableSeparator = separador.ToString();
            //Parametros de lectura de plantilla
            object fileName = m_PlantillaDocPath;
            object confirmConversions = Type.Missing;
            object readOnly = Type.Missing;
            object addToRecentFiles = Type.Missing;
            object passwordDoc = Type.Missing;
            object passwordTemplate = Type.Missing;
            object revert = Type.Missing;
            object writepwdoc = Type.Missing;
            object writepwTemplate = Type.Missing;
            object format = Type.Missing;
            object encoding = Type.Missing;
            object visible = Type.Missing;
            object openRepair = Type.Missing;
            object docDirection = Type.Missing;
            object notEncoding = Type.Missing;
            object xmlTransform = Type.Missing;

            //Abrir la plantilla
            Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(
                ref fileName,
                ref confirmConversions,
                ref readOnly,
                ref addToRecentFiles,
                ref passwordDoc,
                ref passwordTemplate,
                ref revert,
                ref writepwdoc,
                ref writepwTemplate,
                ref format,
                ref encoding,
                ref visible,
                ref openRepair,
                ref docDirection,
                ref notEncoding
            );

            //Parámetros para el MailMerge
            string Name = m_CsvPath; //OdcPath;
            object Format = "wdOpenFormatAuto";// Type.Missing;
            object ConfirmConversions = Type.Missing;
            object ReadOnly = Type.Missing;
            object LinkToSource = Type.Missing;
            object AddToRecentFiles = Type.Missing;
            object PasswordDocument = Type.Missing;
            object PasswordTemplate = Type.Missing;
            object Revert = Type.Missing;
            object WritePasswordDocument = Type.Missing;
            object WritePasswordTemplate = Type.Missing;
            object Connection = Type.Missing;
            object SQLStatement = Type.Missing;
            object SQLStatement1 = Type.Missing;
            object OpenExclusive = Type.Missing;
            object SubType = Type.Missing;

            //Inicio del MailMerge
            wordDoc.MailMerge.OpenDataSource(
                Name,
                ref Format,
                ref ConfirmConversions,
                ref ReadOnly,
                ref LinkToSource,
                ref AddToRecentFiles,
                ref PasswordDocument,
                ref PasswordTemplate,
                ref Revert,
                ref WritePasswordDocument,
                ref WritePasswordTemplate,
                ref Connection,
                ref SQLStatement,
                ref SQLStatement1,
                ref OpenExclusive,
                ref SubType
            );

            //Do fancy things
            wordApp.Visible = true;
            wordDoc.RemovePersonalInformation = true;
            wordDoc.MailMerge.Destination = 0;
            wordDoc.MailMerge.SuppressBlankLines = true;
            wordDoc.MailMerge.DataSource.FirstRecord = 1;
            wordDoc.MailMerge.DataSource.LastRecord = -16;
            Object pause = false;
            wordDoc.MailMerge.Execute(ref pause);

            object SaveChanges = false;
            object OriginalFormat = Type.Missing;
            object RouteDocument = Type.Missing;

            // Exportar a PDF
            if (m_GeneraPdf)
            {
                wordApp.ActiveDocument.ExportAsFixedFormat(m_CorrespondenciaPdfPath, WdExportFormat.wdExportFormatPDF);
            }

            // Cerrar el documento de la plantilla
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
            wordDoc = null;

            if (m_CerrarAplicacion)
            {
                wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                wordApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            #endregion [MailMerge]
        }

        /// <summary>
        /// Elimina los archivos de plantilla, csv y schema
        /// </summary>
        private void EliminaTemporales()
        {
            if (m_Exporta == false)
            {
                if (File.Exists(m_PlantillaDocPath))
                {
                    File.Delete(m_PlantillaDocPath);
                }
                if (File.Exists(m_CsvPath))
                {
                    File.Delete(m_CsvPath);
                }
                if (File.Exists(m_SchemaIniPath))
                {
                    File.Delete(m_SchemaIniPath);
                }
            }
        }

        #endregion [Metodos]
    }
}