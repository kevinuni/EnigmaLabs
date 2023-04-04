﻿using ControlsUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public class frmGridview : Form
    {
        private DataGridView DataGridView1 = new DataGridView();
        private DataGridView DataGridView2 = new DataGridView();

        public frmGridview()
        {
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                SetUpForm();
                SetUpDataGridView1();
                SetUpDataGridView2();
                ThemeManager.UseTheme(this);
            }
            catch (SqlException)
            {
                MessageBox.Show("The connection string <"
                    + connectionString
                    + "> failed to connect.  Modify it "
                    + "to connect to a Northwind database accessible to "
                    + "your system.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void SetUpForm()
        {
            Size = new Size(800, 600);
            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Dock = DockStyle.Fill;
            Controls.Add(flowLayout);
            Text = "DataGridView columns demo";

            flowLayout.Controls.Add(DataGridView1);
            flowLayout.Controls.Add(DataGridView2);
        }

        private void SetUpDataGridView2()
        {
            DataGridView2.Dock = DockStyle.Bottom;
            DataGridView2.TopLeftHeaderCell.Value = "Sales Details";
            DataGridView2.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void SetUpDataGridView1()
        {
            DataGridView1.DataError += new
                DataGridViewDataErrorEventHandler(DataGridView1_DataError);
            DataGridView1.CellContentClick += new
                DataGridViewCellEventHandler(DataGridView1_CellContentClick);
            DataGridView1.CellValuePushed += new
                DataGridViewCellValueEventHandler(DataGridView1_CellValuePushed);
            DataGridView1.CellValueNeeded += new
                DataGridViewCellValueEventHandler(DataGridView1_CellValueNeeded);

            // Virtual mode is turned on so that the
            // unbound DataGridViewCheckBoxColumn will
            // keep its state when the bound columns are
            // sorted.
            DataGridView1.VirtualMode = true;
            DataGridView1.AutoSize = true;
            DataGridView1.DataSource = Populate("SELECT * FROM Employees");
            DataGridView1.TopLeftHeaderCell.Value = "Employees";
            DataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AllowUserToDeleteRows = false;

            // The below autogenerated column is removed so
            // a DataGridViewComboboxColumn could be used instead.
            DataGridView1.Columns.Remove(ColumnName.TitleOfCourtesy.ToString());
            DataGridView1.Columns.Remove(ColumnName.ReportsTo.ToString());

            AddLinkColumn();
            AddComboBoxColumns();
            AddButtonColumn();
            AddOutOfOfficeColumn();
        }

        private void AddComboBoxColumns()
        {
            DataGridViewComboBoxColumn comboboxColumn;
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingDataSource(comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via DataSource property)";
            DataGridView1.Columns.Insert(0, comboboxColumn);

            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingItems(comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via Items property)";
            // Tack this example column onto the end.
            DataGridView1.Columns.Add(comboboxColumn);
        }

        private void AddLinkColumn()
        {
            DataGridViewLinkColumn links = new DataGridViewLinkColumn();

            links.UseColumnTextForLinkValue = true;
            links.HeaderText = ColumnName.ReportsTo.ToString();
            links.DataPropertyName = ColumnName.ReportsTo.ToString();
            links.ActiveLinkColor = Color.White;
            links.LinkBehavior = LinkBehavior.SystemDefault;
            links.LinkColor = Color.Blue;
            links.TrackVisitedState = true;
            links.VisitedLinkColor = Color.YellowGreen;

            DataGridView1.Columns.Add(links);
        }

        private static void SetAlternateChoicesUsingItems(
            DataGridViewComboBoxColumn comboboxColumn)
        {
            comboboxColumn.Items.AddRange("Mr.", "Ms.", "Mrs.", "Dr.");
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = ColumnName.TitleOfCourtesy.ToString();
                column.HeaderText = ColumnName.TitleOfCourtesy.ToString();
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }

        private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.DataSource = RetrieveAlternativeTitles();
                comboboxColumn.ValueMember = ColumnName.TitleOfCourtesy.ToString();
                comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
            }
        }

        private DataTable RetrieveAlternativeTitles()
        {
            return Populate("SELECT distinct TitleOfCourtesy FROM Employees");
        }

        private string connectionString =
            "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=ENIGMA";

        private DataTable Populate(string sqlCommand)
        {
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        // Using an enum provides some abstraction between column index
        // and column name along with compile time checking, and gives
        // a handy place to store the column names.
        private enum ColumnName
        {
            EmployeeId,
            LastName,
            FirstName,
            Title,
            TitleOfCourtesy,
            BirthDate,
            HireDate,
            Address,
            City,
            Region,
            PostalCode,
            Country,
            HomePhone,
            Extension,
            Photo,
            Notes,
            ReportsTo,
            PhotoPath,
            OutOfOffice
        };

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Sales";
                buttons.Text = "Sales";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 0;
            }

            DataGridView1.Columns.Add(buttons);
        }

        private void AddOutOfOfficeColumn()
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = ColumnName.OutOfOffice.ToString();
                column.Name = ColumnName.OutOfOffice.ToString();
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = true;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }

            DataGridView1.Columns.Insert(0, column);
        }

        private void PopulateSales(DataGridViewCellEventArgs buttonClick)
        {
            string employeeId = DataGridView1.Rows[buttonClick.RowIndex]
                .Cells[ColumnName.EmployeeId.ToString()].Value.ToString();
            DataGridView2.DataSource = Populate("SELECT * FROM Orders WHERE EmployeeId = " + employeeId);
        }

        #region "SQL Error handling"

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        #endregion "SQL Error handling"

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
                MoveToLinked(e);
            }
            else if (IsANonHeaderButtonCell(e))
            {
                PopulateSales(e);
            }
        }

        private void MoveToLinked(DataGridViewCellEventArgs e)
        {
            string employeeId;
            object value = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (value is DBNull) { return; }

            employeeId = value.ToString();
            DataGridViewCell boss = RetrieveSuperiorsLastNameCell(employeeId);
            if (boss != null)
            {
                DataGridView1.CurrentCell = boss;
            }
        }

        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (DataGridView1.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return false; }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (DataGridView1.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }

        private DataGridViewCell RetrieveSuperiorsLastNameCell(string employeeId)
        {
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (row.IsNewRow) { return null; }
                if (row.Cells[ColumnName.EmployeeId.ToString()].Value.ToString().Equals(employeeId))
                {
                    return row.Cells[ColumnName.LastName.ToString()];
                }
            }
            return null;
        }

        #region "checkbox state"

        private Dictionary<string, bool> inOffice = new Dictionary<string, bool>();

        private void DataGridView1_CellValuePushed(object sender,
            DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                string employeeId = GetKey(e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    inOffice.Add(employeeId, (Boolean)e.Value);
                }
                else
                {
                    inOffice[employeeId] = (Boolean)e.Value;
                }
            }
        }

        private string GetKey(DataGridViewCellValueEventArgs cell)
        {
            return DataGridView1.Rows[cell.RowIndex].
                Cells[ColumnName.EmployeeId.ToString()].Value.ToString();
        }

        private void DataGridView1_CellValueNeeded(object sender,
            DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                string employeeId = GetKey(e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    bool defaultValue = false;
                    inOffice.Add(employeeId, defaultValue);
                }

                e.Value = inOffice[employeeId];
            }
        }

        private bool IsCheckBoxColumn(int columnIndex)
        {
            DataGridViewColumn outOfOfficeColumn =
                DataGridView1.Columns[ColumnName.OutOfOffice.ToString()];
            return (DataGridView1.Columns[columnIndex] == outOfOfficeColumn);
        }

        #endregion "checkbox state"
    }
}