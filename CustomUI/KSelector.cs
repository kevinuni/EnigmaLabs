using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlsUI
{
    public partial class KSelector<T, W> : UserControl
        where T : class, IEntityToSearch
        where W : IDriver<T>, new()
    {
        #region [Private]

        private List<T> lstCache = new List<T>();
        protected T m_CurrentObject;
        private W m_Meta;

        private string PatronDeBusqueda = string.Empty;
        private int sPosition = 0;
        private int m_MinLengthToSearch;

        /// <summary>
        /// Variable de control para saber si el evento ya ha KSelect disparado(para evitar disparar dos veces el mismo evento)
        /// </summary>
        private bool m_HasFired = false;

        private T m_LastEntityDescriptor;

        #endregion [Private]

        #region [Publicos]

        public bool HasFired
        {
            get { return m_HasFired; }
            set { m_HasFired = value; }
        }

        public int DropdownWidth
        {
            get { return cbbCombo.DropDownWidth; }
            set { cbbCombo.DropDownWidth = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public T CurrentObject
        {
            get
            {
                return m_CurrentObject;
            }
            set
            {
                RunMetaEntity(value);
            }
        }

        #endregion [Publicos]

        #region [Eventos]

        public delegate void SetEntity_Delegate(bool result, T EntityDescriptor);

        public event SetEntity_Delegate SetEntity_Event;

        #endregion [Eventos]

        public KSelector()
        {
            InitializeComponent();

            m_MinLengthToSearch = 4;
            m_Meta = new W();
            m_CurrentObject = m_Meta.GetEntityTNinguno;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #region [Metodos]

        /// <summary>
        /// Fija la entidad al control, pinta y pasa el control al formulario padre
        /// </summary>
        /// <param name="entidadT">Entidad</param>
        protected virtual void RunMetaEntity(T entidadT)
        {
            try
            {
                //averiguar si es un valor valido
                if (IsValorAceptable(entidadT))
                {
                    m_CurrentObject = entidadT;

                    if (IsEntityNinguno(entidadT))
                    {
                        //pintar valores en el control
                        this.cbbCombo.Text = string.Empty;

                        //pintar colores en el control
                        this.cbbCombo.BackColor = System.Drawing.Color.MistyRose;
                    }
                    else
                    {
                        //pintar valores en el control
                        this.cbbCombo.Text = entidadT.DisplayMember;

                        //pintar colores en el control
                        this.cbbCombo.BackColor = System.Drawing.Color.White;

                        lstCache = new List<T>();
                        lstCache.Add(entidadT);

                        cbbCombo.DataSource = null;
                        cbbCombo.DataSource = BE_ComboDecorator<T>.ListFactory(lstCache);
                        cbbCombo.DisplayMember = Constantes.DISPLAY_MEMBER;
                        cbbCombo.ValueMember = Constantes.VALUE_MEMBER;

                        //ubicar el cursor correctamente
                        cbbCombo.SelectedIndex = 0;
                        cbbCombo.Text = ((T)entidadT).DisplayMember;
                        cbbCombo.SelectionStart = sPosition;
                    }
                }
                else
                {
                    throw new Exception("El valor no coincide con el tipo esperado. (code: wycVtPGr)");
                }

                bool EntityHasValue = !IsEntityNinguno(entidadT);
                if (!EntityHasValue)
                {
                    cbbCombo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Si el objeto no es null, está garantizado que corresponde a un IEntityDescriptor del tipo adecuado
        /// dado que la entrada de objetos solo se realiza mediante la propiedad CurrentObject y el
        /// método PaintMetaEntity del objeto heredado, ambos fuerzan el tipo
        /// </summary>
        /// <param name="entidadT"></param>
        /// <returns></returns>
        private bool IsValorAceptable(T entidadT)
        {
            if (entidadT == null && m_Meta.GetEntityTNinguno != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Averigua si bcMetaEntity corresponde a un valor del tipo ninguno para BE o null para BC
        /// Nota: Este método no verifica la integridad de bcMetaEntity. Asegurarse de llamar a IsValorAceptable primero
        /// </summary>
        /// <param name="entidadT"></param>
        /// <returns></returns>
        private bool IsEntityNinguno(T entidadT)
        {
            if (m_Meta.GetEntityTNinguno == null && entidadT == m_Meta.GetEntityTNinguno)
            {
                //si proviene de un BC
                return true;
            }
            else
                if (m_Meta.GetEntityTNinguno != null && m_Meta.GetEntityTNinguno.GetType() == entidadT.GetType())
            {
                //si proviene de un BE
                return true;
            }
            return false;
        }

        private void ConfiguraModoPresentacion()
        {
            cbbCombo.Size = new Size(this.Size.Width - cbbCombo.Location.X, cbbCombo.Size.Height);
        }

        #endregion [Metodos]

        private void cPersonaGeneric_Load(object sender, EventArgs e)
        {
            ConfiguraModoPresentacion();
        }

        private void btnFinder_Click(object sender, EventArgs e)
        {
            frmFinder<T, W> form = new frmFinder<T, W>(CustomForm.FORM_MODE.Selection);

            if (form.ShowDialog() == DialogResult.OK)
            {
                T entityT = form.CurrentObject;
                RunMetaEntity(entityT);
                //Enviar el evento
                FireEvent(entityT != null, entityT);
            }
            else
            {
                RunMetaEntity(m_Meta.GetEntityTNinguno);
                //Enviar el evento
                FireEvent(false, m_Meta.GetEntityTNinguno);
            }
        }

        private void btnCtaCteCancel_Click(object sender, EventArgs e)
        {
            RunMetaEntity(m_Meta.GetEntityTNinguno);
            //Enviar evento
            FireEvent(false, m_Meta.GetEntityTNinguno);
            cbbCombo.Focus();
        }

        private char KeyToChar(Keys key, int keyvalue)
        {
            //a-z, 0-9
            if ((keyvalue >= 48 && keyvalue <= 57) || (keyvalue >= 65 && keyvalue <= 90))
            {
                return Convert.ToChar(keyvalue);
            }
            else
            {
                switch (key)
                {
                    case Keys.Decimal:
                    case Keys.OemPeriod:
                        return '.';

                    case Keys.Space:
                        return ' ';

                    case Keys.NumPad0:
                        return '0';

                    case Keys.NumPad1:
                        return '1';

                    case Keys.NumPad2:
                        return '2';

                    case Keys.NumPad3:
                        return '3';

                    case Keys.NumPad4:
                        return '4';

                    case Keys.NumPad5:
                        return '5';

                    case Keys.NumPad6:
                        return '6';

                    case Keys.NumPad7:
                        return '7';

                    case Keys.NumPad8:
                        return '8';

                    case Keys.NumPad9:
                        return '9';
                }
            }
            return '*';
        }

        private void gbbCtaCteIni_KeyDown(object sender, KeyEventArgs e)
        {
            char key = KeyToChar(e.KeyData, e.KeyValue);
            if (key != '*') //todos los alfanumericos
            {
                PatronDeBusqueda += key.ToString();
                PintarCombo();
            }
            else if (e.KeyData == Keys.Back)
            {
                if (PatronDeBusqueda.Length > 0)
                {
                    PatronDeBusqueda = PatronDeBusqueda.Substring(0, PatronDeBusqueda.Length - 1);
                }
                PintarCombo();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Escape
                PatronDeBusqueda = string.Empty;
                RunMetaEntity(m_Meta.GetEntityTNinguno);
                cbbCombo.SelectedIndex = -1;
                cbbCombo.DroppedDown = false;
                FireEvent(false, m_Meta.GetEntityTNinguno);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                PatronDeBusqueda = string.Empty;
                cbbCombo.SelectionStart = PatronDeBusqueda.Length;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (cbbCombo.Items.Count > 0 && cbbCombo.SelectedItem != null)
                {
                    this.cbbCombo.DropDownClosed -= new System.EventHandler(this.cbbCombo_DropDownClosed);
                    cbbCombo.DroppedDown = false;
                    this.cbbCombo.DropDownClosed += new System.EventHandler(this.cbbCombo_DropDownClosed);
                }
                else
                {
                    cbbCombo.DroppedDown = false;
                }
                if (cbbCombo.Items.Count > 0)
                {
                    BE_ComboDecorator<T> be = (BE_ComboDecorator<T>)cbbCombo.SelectedItem;
                    if (be != null)
                    {
                        T bc = (T)be.BE_Entity;
                        RunMetaEntity(bc);
                        //Enviar evento
                        FireEvent(true, bc);
                        SaltarControl();
                    }
                    else
                    {
                        FireEvent(false, m_Meta.GetEntityTNinguno);
                    }
                }
                else
                {
                    if (PatronDeBusqueda.Trim() == string.Empty)
                    {
                        SaltarControl();
                    }
                    cbbCombo.SelectedIndex = -1;
                    RunMetaEntity(m_Meta.GetEntityTNinguno);
                }
                PatronDeBusqueda = string.Empty;
            }
            else
            {
                PatronDeBusqueda = string.Empty;
            }

            //bloquear el caracter excepto para subir y bajar por el control
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                e.SuppressKeyPress = true;
            }
        }

        protected virtual void SaltarControl()
        {
            //    //TabNextControl.GoNextControl(this.ActiveControl);
        }

        private void PintarCombo()
        {
            sPosition = PatronDeBusqueda.Length;

            cbbCombo.DataSource = null;
            cbbCombo.DisplayMember = Constantes.DISPLAY_MEMBER;
            cbbCombo.ValueMember = Constantes.VALUE_MEMBER;

            //si no está despegado desplegar
            cbbCombo.DropDownHeight = 200;
            if (!cbbCombo.DroppedDown)
            {
                cbbCombo.DroppedDown = true;
            }

            if (PatronDeBusqueda.Length == m_MinLengthToSearch)
            {
                //recuperar de la base de datos
                lstCache = m_Meta.GetByPattern(PatronDeBusqueda);

                if (lstCache.Count > 0)
                {
                    lstCache.Sort();
                    cbbCombo.DataSource = BE_ComboDecorator<T>.ListFactory(lstCache);
                }
            }
            else if (PatronDeBusqueda.Length > m_MinLengthToSearch)
            {
                List<T> lstFiltrado = new List<T>();
                foreach (T bc in lstCache)
                {
                    if (bc.CompareDisplayMemberTo(PatronDeBusqueda))
                        lstFiltrado.Add(bc);
                }
                if (lstFiltrado.Count > 0)
                {
                    lstFiltrado.Sort();
                    cbbCombo.DataSource = BE_ComboDecorator<T>.ListFactory(lstFiltrado);
                }
            }

            //ubicar el cursor correctamente
            cbbCombo.SelectedIndex = -1;
            cbbCombo.Text = PatronDeBusqueda;
            cbbCombo.SelectionStart = sPosition;
        }

        private void gbbCtaCteIni_MouseClick(object sender, MouseEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            int xinicial = cbbCombo.Size.Width - 20;
            int xfinal = cbbCombo.Size.Width;
            int yinicial = 0;
            int yfinal = cbbCombo.Size.Height;

            //cuando se presione el botón de despliegue
            if (combo.Text.Trim().Length == 0 && e.X >= xinicial && e.X <= xfinal && e.Y >= yinicial && e.Y <= yfinal)
            {
                combo.DataSource = null;
                combo.DisplayMember = Constantes.DISPLAY_MEMBER;
                combo.ValueMember = Constantes.VALUE_MEMBER;

                //si no está despegado desplegar
                combo.DropDownHeight = 200;
                if (!combo.DroppedDown)
                {
                    combo.DroppedDown = true;
                }

                //cargar de datos
                lstCache = m_Meta.GetByPattern(combo.Text);

                if (lstCache.Count > 0)
                {
                    lstCache.Sort();
                    combo.DataSource = BE_ComboDecorator<T>.ListFactory(lstCache);
                }

                //ubicar el cursor correctamente
                combo.SelectedIndex = -1;
                combo.Text = PatronDeBusqueda;
                combo.SelectionStart = sPosition;
            }
        }

        //protected string Text
        //{
        //    get
        //    {
        //        return cbbCombo.Text;
        //    }
        //}

        private void cbbCombo_DropDownClosed(object sender, EventArgs e)
        {
            //Evitar q al abandonar el control o presionar enter cuando no hay un item seleccionado
            //se genere una excepcion
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex == 0 && combo.Items.Count == 0)
            {
                combo.SelectedIndex = -1;
            }
            else if (combo.SelectedIndex == -1)
            {
            }
            else
            {
                RunMetaEntity((T)((BE_ComboDecorator<T>)combo.SelectedItem).BE_Entity);
            }

            if (combo.SelectedIndex != -1)
            {
                FireEvent(true, (T)((BE_ComboDecorator<T>)combo.SelectedItem).BE_Entity);
            }
        }

        /// <summary>
        /// Disparador ultimo del evento
        /// </summary>
        /// <param name="result"></param>
        /// <param name="EntityDescriptor"></param>
        private void FireEvent(bool result, T entidadT)
        {
            if (SetEntity_Event != null)
            {
                if (entidadT != m_LastEntityDescriptor)
                {
                    SetEntity_Event(result, entidadT);
                }
                m_LastEntityDescriptor = entidadT;
            }
        }
    }
}