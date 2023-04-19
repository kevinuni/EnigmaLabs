using CSUST.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ControlsUI
{
    public partial class ColumnFactory
    {
        public static DataGridViewLinkColumn LinkColumnStyle(string propertyname, string headerText)
        {
            DataGridViewLinkColumn column = new DataGridViewLinkColumn();
            column.DataPropertyName = propertyname;

            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.HeaderText = headerText;
            column.Name = propertyname;
            column.Width = 100;
            column.ReadOnly = false;
            column.UseColumnTextForLinkValue = true;

            return column;
        }

        public static DataGridViewButtonColumn ButtonColumnStyle(string propertyname, string headerText)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.DataPropertyName = propertyname;

            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.HeaderText = headerText;
            column.Name = propertyname;
            column.Width = 100;
            column.ReadOnly = false;
            // column.UseColumnTextForLinkValue = true;

            return column;
        }

        /// <summary>
        /// Columna de tipo Buttonimage.
        /// </summary>
        /// <param name="propertyname">El propertyname solamente sirve para obtener el valor del tooltip</param>
        /// <param name="headerText"></param>
        /// <returns></returns>
        public static DataGridViewButtonColumn ImageButtonColumnStyle(string propertyname, string headerText)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.DataPropertyName = propertyname;

            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.HeaderText = headerText;
            column.Name = propertyname;
            column.Width = 100;
            column.ReadOnly = false;
            // column.UseColumnTextForLinkValue = true;

            return column;
        }

        public static DataGridViewColumn TextColumnStyle(string propertyname, string headerText)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = propertyname;
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column.HeaderText = headerText;
            column.Name = propertyname;
            column.Width = 100;
            column.ReadOnly = false;
            return column;
        }

        public static DataGridViewColumn TextColumnStyle(string propertyname, string headerText, bool pReadonly)
        {
            DataGridViewColumn col = TextColumnStyle(propertyname, headerText);
            col.ReadOnly = pReadonly;
            if (pReadonly)
            {
                col.DefaultCellStyle.ForeColor = Color.Gray;
            }
            return col;
        }

        public static DataGridViewColumn TextColumnStyle(string propertyname, string headerText, int width)
        {
            DataGridViewColumn col = TextColumnStyle(propertyname, headerText);
            col.Width = width;
            return col;
        }

        public static DataGridViewColumn CheckBoxColumnStyle(string pDataPropertyName, string pHeaderText, bool pReadOnly = false, bool pVisible = true)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.DataPropertyName = pDataPropertyName;
            column.HeaderText = pHeaderText;
            column.FalseValue = false;
            column.ReadOnly = pReadOnly;
            if (pReadOnly)
            {
                column.DefaultCellStyle.ForeColor = Color.Gray;
            }
            column.TrueValue = true;
            column.Visible = pVisible;
            return column;
        }

        public static DataGridViewTextBoxColumn DateTimeColumnStyle(string pDataPropertyName, string pHeaderText, int width, string format, bool pReadOnly = false, bool pVisible = true)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.CellTemplate.Style.Format = format;
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.DataPropertyName = pDataPropertyName;
            column.HeaderText = pHeaderText;
            column.Name = pDataPropertyName;
            column.ReadOnly = pReadOnly;
            if (pReadOnly)
            {
                column.DefaultCellStyle.ForeColor = Color.Gray;
            }
            column.Visible = pVisible;
            column.Width = width;
            return column;
        }

        public static DataGridViewTextBoxColumn DecimalColumnStyle(string pDataPropertyName, string pHeaderText, int width, int decimaldigits = 4, bool pReadOnly = false, bool pVisible = true)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberDecimalDigits = decimaldigits;
            nfi.NumberGroupSeparator = ",";

            TNumEditDataGridViewColumn column = new TNumEditDataGridViewColumn();
            column.AllowNegative = false;
            column.CellTemplate.Style.Format = "N";
            column.CellTemplate.Style.FormatProvider = nfi;
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.DataPropertyName = pDataPropertyName;
            column.DecimalLength = decimaldigits;
            column.HeaderText = pHeaderText;
            column.Name = pDataPropertyName;

            column.ReadOnly = pReadOnly;
            if (pReadOnly)
            {
                column.DefaultCellStyle.ForeColor = Color.Gray;
            }
            column.Visible = pVisible;
            column.Width = width;
            return column;
        }

        public static DataGridViewTextBoxColumn CurrencyColumnStyle(string pDataPropertyName, string pHeaderText, int decimaldigits = 3, bool pReadOnly = false, bool pVisible = true)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencyDecimalDigits = decimaldigits;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.CurrencyGroupSeparator = Constantes.NUMBERGROUPSEPARATOR;

            TNumEditDataGridViewColumn column = new TNumEditDataGridViewColumn();
            column.AllowNegative = false;
            column.CellTemplate.Style.Format = "N";
            column.CellTemplate.Style.FormatProvider = nfi;
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.DataPropertyName = pDataPropertyName;
            column.DecimalLength = decimaldigits;
            column.HeaderText = pHeaderText;
            column.Name = pDataPropertyName;
            column.ReadOnly = pReadOnly;
            if (pReadOnly)
            {
                column.DefaultCellStyle.ForeColor = Color.Gray;
            }
            column.Visible = pVisible;
            return column;
        }

        public static DataGridViewTextBoxColumn IntegerColumnStyle(string pDataPropertyName, string pHeaderText, bool pReadOnly = false, bool pVisible = true)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSeparator = Constantes.NUMBERGROUPSEPARATOR;

            TNumEditDataGridViewColumn column = new TNumEditDataGridViewColumn();
            column.AllowNegative = false;
            column.CellTemplate.Style.Format = "N";
            column.CellTemplate.Style.FormatProvider = nfi;
            column.CellTemplate.Style.NullValue = string.Empty;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.HeaderText = pHeaderText;
            column.DataPropertyName = pDataPropertyName;
            column.Name = pDataPropertyName;
            column.ReadOnly = pReadOnly;
            if (pReadOnly)
            {
                column.DefaultCellStyle.ForeColor = Color.Gray;
            }
            column.Visible = pVisible;
            return column;
        }

        public static DataGridViewComboBoxColumn ComboboxColumnStyle<T>(string pDataPropertyName, string pHeaderText, int pWidth, List<T> datasource, string DisplayMember, string ValueMember)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.HeaderText = pHeaderText;
            column.DataPropertyName = pDataPropertyName;
            column.DisplayMember = DisplayMember;
            column.ValueMember = ValueMember;
            column.ValueType = typeof(T);
            column.ReadOnly = false;
            column.DataSource = datasource;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            column.CellTemplate.Style.NullValue = null;
            column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            column.Name = pDataPropertyName;

            column.Width = pWidth;
            return column;
        }
    }
}