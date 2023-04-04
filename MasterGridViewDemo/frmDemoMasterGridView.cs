using CustomUI;
using System;
using System.Windows.Forms;

namespace MasterGridViewDemo
{
    public partial class frmDemoMasterGridView : Form
    {
        public frmDemoMasterGridView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewColumnCollection columns = dgvStudents.Columns;
            columns.Add(ColumnFactory.TextColumnStyle("FirstName", "FirstName"));
            columns.Add(ColumnFactory.TextColumnStyle("LastName", "LastName"));

            BindingSource bs = new BindingSource();
            bs.DataSource = Student.getStudents();

            dgvStudents.DataSource = bs;
            dgvStudents.Dock = DockStyle.Fill;

            //Agregar la grilla
            this.Controls.Add(dgvStudents);
            dgvStudents.SetChild();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}