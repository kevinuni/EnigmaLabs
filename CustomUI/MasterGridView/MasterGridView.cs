using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Util;

namespace ControlsUI
{
    public class MasterGridView : DataGridView
    {
        private IGridConfiguration _gridConfiguration;

        public void SetConfiguration(IGridConfiguration gridConfiguration)
        {
            _gridConfiguration = gridConfiguration;

            _gridConfiguration.ConfigGrid(this);

            DetailTabControl detailTabControl = new DetailTabControl(_gridConfiguration)
            {
                Height = this.rowExpandedDivider - this.rowDividerMargin * 2,
                Visible = false
            };

            this.detailTabControl = detailTabControl;
        }

        public List<int> lstCurrentRows = new List<int>();
        public int rowDefaultHeight { get; set; } = 22;
        public int rowExpandedHeight { get; set; } = 300;
        public int rowDefaultDivider { get; set; } = 0;
        public int rowExpandedDivider { get; set; } = 300 - 22;
        public int rowDividerMargin { get; set; } = 5;
        public bool doCollapseRow;

        private ImageList rowHeaderIconList = new ImageList();

        public DetailTabControl detailTabControl { get; set; }

        private System.ComponentModel.IContainer components;

        public enum rowHeaderIcons
        {
            expand = 1,
            collapse = 0
        }

        public MasterGridView()
        {
            InitializeComponent();

            //rowHeaderIconList.Images.Add(Datos.expanded);
            //rowHeaderIconList.Images.Add(Datos.collapsed);
            //rowHeaderIconList.TransparentColor = System.Drawing.Color.Transparent;
            //rowHeaderIconList.Images.SetKeyName(1, "expanded.gif");
            //rowHeaderIconList.Images.SetKeyName(0, "collapsed.gif");

            Scroll += MasterControl_Scroll;

            // Dibuja el símbolo "+"
            RowPostPaint += MasterControl_RowPostPaint;

            // Al dar click en el símbolo "+" del rowheader
            RowHeaderMouseClick += MasterControl_RowHeaderMouseClick;

            // Mostrar en un tooltip la descripción de la Propiedad cuando se pase el mouse por encima
            CellMouseEnter += MasterGridView_CellMouseEnter;

            // Limpiar la celda cuando se presiona ESC
            CellEndEdit += MasterGridView_CellEndEdit;

            // Eliminar registros o abrir detalles
            KeyDown += MasterGridView_KeyDown;

            Layout += MasterGridView_Layout;
        }

        private void MasterGridView_Layout(object sender, LayoutEventArgs e)
        {
            // Se invoca al cargar el form, similar a Load()
            BeginInvoke(new Action(() =>
            {
                _gridConfiguration.ApplyTheme(this);
            }));

            _gridConfiguration.SetGridColumnStyleAfterBinding(this);
            this.SetChildLevelUI();

            this.Layout -= MasterGridView_Layout;
        }

        private void MasterGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MasterGridView grid = (MasterGridView)sender;

            // Clear the row error in case the user presses ESC.
            grid.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void MasterGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // refrescar las celdas a las que no se les haya hecho commit
            if (this.IsCurrentCellDirty)
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MasterGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.Delete))
            {
                BindingSource bs = (BindingSource)this.DataSource;

                if (bs.Current != null)
                {
                    //TODO pendiente validar que no se esté usando en otros lados
                    if (MessageBox.Show("Está seguro de eliminar " + bs.Current.ToString(), "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bs.RemoveCurrent();
                    }
                }
            }
            else if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                // abrir detalle
                ExpandDetail(this.CurrentRow.Index);
            }
        }

        //private void comboOpt2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Delete))
        //    {
        //        ComboBox combo = (ComboBox)this.EditingControl;
        //        combo.SelectedIndex = -1;
        //    }
        //}

        //private void comboOpt1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Delete))
        //    {
        //        ComboBox combo = (ComboBox)this.EditingControl;
        //        combo.SelectedIndex = -1;
        //    }
        //}

        private ToolTip tt = new ToolTip();

        private void MasterGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Show tooltip of Property Description in Header's Column
            if (e.RowIndex == -1 && e.ColumnIndex != -1 && this.DataSource != null)
            {
                string description = string.Empty;
                if (DataSource is BindingSource)
                {
                    var tipo = ((BindingSource)DataSource).Current.GetType();
                    var property = tipo.GetProperty(this.Columns[e.ColumnIndex].DataPropertyName);
                    description = TypeMethods.GetDescriptionFromPropertyInfo(property);
                }
                else
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(description))
                {
                    tt.Hide(this);
                }
                else
                {
                    tt.SetToolTip(this, description);
                }
            }
            //else
            //{
            //    tt.Hide(this);
            //}
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterGridView));

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Indica si el objeto contiene listas genéricas
        /// Nota: Tener en cuenta que no todas las listas genéricas se convierten en grillas hijas
        /// </summary>
        /// <returns></returns>
        private bool HasDetailList()
        {
            bool hasDetailList = false;

            Type currentType = null;

            if (DataSource is BindingSource)
            {
                currentType = ((BindingSource)DataSource).Current.GetType();
            }

            foreach (FieldInfo field in currentType.GetFields())
            {
                if (IsNonPrimitiveList(field.FieldType))
                {
                    hasDetailList |= true;
                }
            }

            return hasDetailList;
        }

        /// <summary>
        /// Look if field is a list of non-primitive type
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private bool IsNonPrimitiveList(Type type)
        {
            return
                type.IsGenericType
                && type.GetGenericArguments()[0].IsPrimitive == false;
        }

        /// <summary>
        /// Es necesario fijar la grilla hija al mismo nivel de jerarquia que el Mastergrid
        /// </summary>
        public void SetChildLevelUI()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Add(detailTabControl);
                detailTabControl.BringToFront();
            }
            else
            {
                throw new Exception("The control should be in a container.");
            }
        }

        private void MasterControl_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.X + ((rowDefaultHeight - 16) / 2), e.RowBounds.Y + ((rowDefaultHeight - 16) / 2), 16, 16);

            if (HasDetailList())
            {
                if (doCollapseRow)
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        this.Rows[e.RowIndex].DividerHeight = this.Rows[e.RowIndex].Height - rowDefaultHeight;

                        //e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.collapse], rect);

                        detailTabControl.Location = new Point(e.RowBounds.Left + this.RowHeadersWidth, e.RowBounds.Top + rowDefaultHeight + 5);
                        detailTabControl.Width = e.RowBounds.Right - this.RowHeadersWidth;
                        detailTabControl.Height = this.Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        detailTabControl.Visible = false;
                        //e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.expand], rect);
                    }
                    doCollapseRow = false;
                }
                else
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        this.Rows[e.RowIndex].DividerHeight = this.Rows[e.RowIndex].Height - rowDefaultHeight;
                        //e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.collapse], rect);
                        detailTabControl.Location = new Point(e.RowBounds.Left + this.RowHeadersWidth, e.RowBounds.Top + rowDefaultHeight + 5);
                        detailTabControl.Width = e.RowBounds.Right - this.RowHeadersWidth;
                        detailTabControl.Height = this.Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        //e.Graphics.DrawImage(rowHeaderIconList.Images[(int)rowHeaderIcons.expand], rect);
                    }
                }
            }

            detailTabControl.rowPostPaint_HeaderCount(sender, e);
        }

        private void MasterControl_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.Rows[e.RowIndex].DataBoundItem == null)
            {
                return;
            }
            Rectangle rect = new Rectangle((rowDefaultHeight - 16) / 2, (rowDefaultHeight - 16) / 2, 16, 16);
            if (rect.Contains(e.Location))
            {
                // si se presiona en el símbolo más se abre el detalle
                ExpandDetail(e.RowIndex);
            }
            else
            {
                doCollapseRow = false;
            }
        }

        /// <summary>
        /// Abre/Cierra la subGrilla de detalle
        /// </summary>
        /// <param name="rowIndex">Índice del registro a editar</param>
        private void ExpandDetail(int rowIndex)
        {
            if (lstCurrentRows.Contains(rowIndex))
            {
                lstCurrentRows.Clear();
                this.Rows[rowIndex].Height = rowDefaultHeight;
                this.Rows[rowIndex].DividerHeight = rowDefaultDivider;
            }
            else
            {
                if (lstCurrentRows.Count != 0)
                {
                    int eRow = lstCurrentRows[0];
                    lstCurrentRows.Clear();
                    this.Rows[eRow].Height = rowDefaultHeight;
                    this.Rows[eRow].DividerHeight = rowDefaultDivider;
                    this.ClearSelection();
                    doCollapseRow = true;
                    this.Rows[eRow].Selected = true;
                }

                lstCurrentRows.Add(rowIndex);

                Type parentType = TypeMethods.HeuristicallyDetermineType((IList)this.DataSource);
                object parentObject = this.Rows[rowIndex].DataBoundItem;

                // Detalle
                detailTabControl.TabPages.Clear();

                detailTabControl.openDetailEvent += detailTabControl_OpenDetail;

                if (parentObject != null)
                {
                    foreach (FieldInfo childField in parentType.GetFields())
                    {
                        if (IsNonPrimitiveList(childField.FieldType))
                        {
                            IList listOfDetail = (IList)childField.GetValue(parentObject);

                            string tabTitle = TypeMethods.GetDescriptionFromFieldInfo(childField);

                            detailTabControl.AddChildgrid(listOfDetail, tabTitle);
                        }
                    }
                }

                // expandir la fila
                if (detailTabControl.HasChildren)
                {
                    this.Rows[rowIndex].Height = rowExpandedHeight;
                    this.Rows[rowIndex].DividerHeight = rowExpandedDivider;
                }
                else
                {
                    detailTabControl.Visible = false;
                }
            }
            this.ClearSelection();
            doCollapseRow = true;
            this.Rows[rowIndex].Selected = true;
        }

        private void detailTabControl_OpenDetail()
        {
            // Se invoca al método que abre/cierra la grilla de detalle
            ExpandDetail(this.CurrentRow.Index);
        }

        private void MasterControl_Scroll(object sender, ScrollEventArgs e)
        {
            if (!(lstCurrentRows.Count == 0))
            {
                doCollapseRow = true;
                this.ClearSelection();
                this.Rows[lstCurrentRows[0]].Selected = true;
            }
        }
    }
}