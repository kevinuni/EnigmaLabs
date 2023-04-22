using ConsoleTest.GetStudentModel;
using Enigma.ControlsUI;
using System;
using System.Windows.Forms;

namespace ControlsUIDemo
{
    public partial class frmMasterGridView : Form
    {
        private CustomConfigGrid configGrid = new CustomConfigGrid();

        public frmMasterGridView()
        {
            InitializeComponent();

            //ThemeManager.UseTheme(this);
        }

        private void frmMastergridview_Load(object sender, EventArgs e)
        {
            MasterGridView dgv = new MasterGridView();
            dgv.SetConfiguration(configGrid);

            this.Controls.Add(dgv);

            dgv.AutoGenerateColumns = true;

            BindingSource bs = new BindingSource();
            bs.DataSource = Student.getStudents();

            dgv.DataSource = bs;
            dgv.Dock = DockStyle.Fill;

        }
    }
}