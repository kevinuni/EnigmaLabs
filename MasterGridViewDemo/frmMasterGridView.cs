using KControls;
using System;
using System.Windows.Forms;

namespace MasterGridViewDemo
{
    public partial class frmMasterGridView : Form
    {
        private ConfigGrid configGrid = new ConfigGrid();

        public frmMasterGridView()
        {
            InitializeComponent();

            ThemeManager.UseTheme(this);
        }

        private void frmMastergridview_Load(object sender, EventArgs e)
        {
            MasterGridView masterGridView1 = new MasterGridView();
            masterGridView1.ConfigGrid = configGrid;

            DetailTabControl detailTabControl = new DetailTabControl(configGrid)
            {
                Height = masterGridView1.rowExpandedDivider - masterGridView1.rowDividerMargin * 2,
                Visible = false
            };

            masterGridView1.detailTabControl = detailTabControl;

            this.Controls.Add(masterGridView1);

            masterGridView1.AutoGenerateColumns = true;

            BindingSource bs = new BindingSource();
            bs.DataSource = Persona.getPersonas();

            masterGridView1.DataSource = bs;
            masterGridView1.Dock = DockStyle.Fill;

            //configGrid.SetGridColumnStyleAfterBinding(masterGridView1);
            masterGridView1.SetChild();
        }
    }
}