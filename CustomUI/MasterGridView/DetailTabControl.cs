﻿using Enigma.Util;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public class DetailTabControl : TabControl
    {
        public delegate void OpenDetailDelegate();

        public event OpenDetailDelegate openDetailEvent;

        private IGridConfiguration _configGrid;

        public DetailTabControl(IGridConfiguration configGrid)
        {
            _configGrid = configGrid;
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                if (openDetailEvent != null)
                {
                    openDetailEvent();
                }
            }
            else if (e.Control && e.KeyCode.Equals(Keys.Delete))
            {
                BindingSource bs = (BindingSource)grid.DataSource;

                if (bs.Current != null)
                {
                    //TODO
                    if (MessageBox.Show("Are you sure to delete " + bs.Current.ToString(), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bs.RemoveCurrent();
                    }
                }
            }
        }

        internal void AddChildgrid(IList listOfDetail, string tabTile)
        {
            DataGridView childGrid = new DataGridView();
            // poner un contador en el rowheader
            childGrid.RowPostPaint += rowPostPaint_HeaderCount;
            // Mostrar en un tooltip la descripción de la Propiedad cuando se pase el mouse por encima
            childGrid.CellMouseEnter += newGrid_CellMouseEnter;
            childGrid.CellEndEdit += grid_CellEndEdit;

            childGrid.KeyDown += grid_KeyDown;

            Type childType = TypeMethods.HeuristicallyDetermineType(listOfDetail);
            _configGrid.ConfigChildGrid(childGrid, childType);
            childGrid.ApplyTheme();

            // Agregar la data
            BindingSource bs = new BindingSource();
            bs.DataSource = listOfDetail;
            bs.AllowNew = true;
            childGrid.DataSource = bs;

            if (childType.IsGenericType)
            {
                // Child-types can't be lists (not allowed by now)
                throw new Exception("Child grids with generic types not allowed.");
            }
            else if (childType.IsPrimitive == false)
            {
                // Child-types should be objects, nor primitive types allowed
                TabPage tabpage = new TabPage { Text = tabTile };

                tabpage.ToolTipText = TypeMethods.GetDescriptionFromType(childType);
                tabpage.Controls.Add(childGrid);

                this.TabPages.Add(tabpage);
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            // Clear the row error in case the user presses ESC.
            grid.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private ToolTip tt = new ToolTip();

        /// <summary>
        /// Mostrar en un tooltip la descripción de la Propiedad cuando se pase el mouse por encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView newGrid = (DataGridView)sender;
            BindingSource bs = (BindingSource)newGrid.DataSource;

            // Mostrar en un tooltip la descripción de la Propiedad cuando se pase el mouse por encima
            if (e.RowIndex == -1 && e.ColumnIndex != -1 && newGrid.DataSource != null)
            {
                Type tipo = TypeMethods.HeuristicallyDetermineType((IEnumerable)bs.DataSource);
                var property = tipo.GetProperty(newGrid.Columns[e.ColumnIndex].DataPropertyName);

                if (property != null)
                {
                    var description = TypeMethods.GetDescriptionFromPropertyInfo(property);

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        tt.Hide(newGrid);
                    }
                    else
                    {
                        tt.SetToolTip(newGrid, description);
                    }
                }
            }
            //else
            //{
            //    tt.Hide(newGrid);
            //}
        }

        /// <summary>
        /// Poner un contador el el rowheader (columna de la izquierda)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();
            dynamic centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView.RowHeadersWidth, e.RowBounds.Height  /* - sender.rows(e.RowIndex).DividerHeight*/  );
            e.Graphics.DrawString(rowIdx, dataGridView.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}