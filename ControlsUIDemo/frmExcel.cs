using ControlsUI;
using Excel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public partial class frmExcel : Form
    {
        public frmExcel()
        {
            InitializeComponent();
            ThemeManager.UseTheme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void frmExcel_Load(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IExcelDataReader excelReader = null;

                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            excelReader = ExcelReaderFactory.CreateBinaryReader(myStream);

                            if (Path.GetExtension(openFileDialog1.FileName) == ".xls")
                            {
                                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                                excelReader = ExcelReaderFactory.CreateBinaryReader(myStream);
                            }
                            else if (Path.GetExtension(openFileDialog1.FileName) == ".xlsx")
                            {
                                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                                excelReader = ExcelReaderFactory.CreateOpenXmlReader(myStream);
                            }
                            else
                            {
                                // Error
                                throw new Exception("");
                            }
                            //excelReader.IsFirstRowAsColumnNames = true;

                            DataSet ds = excelReader.AsDataSet();
                            BindingSource bs = new BindingSource();
                            bs.DataSource = ds.Tables[0];

                            dataGridView1.DataSource = bs;

                            //while (excelReader.NextResult());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                if (excelReader != null)
                {
                    //6. Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();
                }
            }
        }
    }
}