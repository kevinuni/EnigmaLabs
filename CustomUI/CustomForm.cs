using System;
using System.Windows.Forms;

namespace ControlsUI
{
    public partial class CustomForm : Form
    {
        #region [Enumerates]

        public enum FORM_MODE
        {
            /// <summary>
            /// Formulario de creación de nuevos registros
            /// </summary>
            New = 1,

            /// <summary>
            /// Formulario para edición de registros existentes
            /// </summary>
            Edition = 2,

            /// <summary>
            /// Formulario para seleccionar registros o para reportes
            /// </summary>
            Selection = 3,

            /// <summary>
            /// Formulario para visualización de registros.
            /// </summary>
            Visualization = 4
        };

        #endregion [Enumerates]

        protected FORM_MODE m_FormMode;

        public FORM_MODE FormMode
        {
            get { return m_FormMode; }
            set { m_FormMode = value; }
        }

        public CustomForm()
        {
            InitializeComponent();

            this.ControlBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
        }

        private void KForm_Load(object sender, EventArgs e)
        {
        }

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}
    }
}