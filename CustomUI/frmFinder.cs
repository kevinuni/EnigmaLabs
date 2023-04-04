using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Util;

namespace ControlsUI
{
    public partial class frmFinder<T, W> : KForm where T : IEntityToSearch where W : IDriver<T>, new()
    {
        private W m_Driver;

        private T m_CurrentObject;

        public frmFinder(FORM_MODE mode)
        {
            InitializeComponent();

            m_FormMode = mode;
            m_Driver = new W();
        }

        public T CurrentObject
        {
            get { return m_CurrentObject; }
        }

        protected void tbtnNuevo_Click(object sender, EventArgs e)
        {
            //frmUnidadEdit frm = new frmUnidadEdit(FORM_MODE.New);
            //frm.KForm_Event += new KForm_Delegate(Actualizar);
            ////frm.MdiParent = SFC_Cache.Instance().MdiForm;
            //frm.ShowDialog();
            ////Formulario.Mostrar(frm, this, false, Configuracion.Instance().Id, Opcion.Util.Recursos.eRecursos.PL037);
        }

        private void tbtnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            this.datagridOfT.DataSource = null;
            List<T> listOfT = m_Driver.GetAll();

            this.datagridOfT.DataSource = listOfT;
        }

        private void frmFindEntity_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            Actualizar();
        }

        private void ConfigurarGrilla()
        {
            datagridOfT.AutoGenerateColumns = false;
            datagridOfT.MultiSelect = false;
            datagridOfT.ReadOnly = true;
            datagridOfT.AllowUserToAddRows = false;
            datagridOfT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridOfT.AllowUserToResizeRows = false;
            datagridOfT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewColumnCollection dgvcColumns = datagridOfT.Columns;

            dgvcColumns.Clear();

            //columnas iniciales

            dgvcColumns.Add(ColumnFactory.TextColumnStyle("descripcion", "Descripción"));
            dgvcColumns.Add(ColumnFactory.TextColumnStyle("simbolo", "Símbolo"));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //verificar la fila seleccionada
            if (m_FormMode == FORM_MODE.Selection && this.datagridOfT.CurrentRow != null)
            {
                //Obtener la fila seleccionada
                DataGridViewRow row = this.datagridOfT.CurrentRow;

                //Recuperar la entidad de la fila seleccionada
                T be = (T)row.DataBoundItem;

                //Seleccionar el objeto
                this.m_CurrentObject = be;

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}