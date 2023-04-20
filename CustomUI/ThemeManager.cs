using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public class ThemeManager
    {
        public enum ThemeStyle
        { Default, Metro, Perseo };

        public static void UseTheme(Control c, ThemeStyle theme = ThemeStyle.Perseo)
        {
            if (c is TextBox)
            {
                ApplyTheme((TextBox)c, theme);
            }
            else if (c is Label)
            {
                ApplyTheme((Label)c, theme);
            }
            else if (c is Form)
            {
                ApplyTheme((Form)c, theme);
            }
            else if (c is GroupBox)
            {
                ApplyTheme((GroupBox)c, theme);
            }
            else if (c is Button)
            {
                ApplyTheme((Button)c, theme);
            }
            else if (c is RadioButton)
            {
                ApplyTheme((RadioButton)c, theme);
            }
            else if (c is CheckBox)
            {
                ApplyTheme((CheckBox)c, theme);
            }
            else if (c is ComboBox)
            {
                ApplyTheme((ComboBox)c, theme);
            }
            else if (c is DataGridView)
            {
                ApplyTheme((DataGridView)c, theme);
            }
            else if (c is MenuStrip)
            {
                ApplyTheme((MenuStrip)c, theme);
            }
            else if (c is ToolStrip)
            {
                ApplyTheme((ToolStrip)c, theme);
            }
            else if (c is StatusBar)
            {
                ApplyTheme((StatusBar)c, theme);
            }
            else if (c is NumericUpDown)
            {
                ApplyTheme((NumericUpDown)c, theme);
            }
            else if (c is DateTimePicker)
            {
                ApplyTheme((DateTimePicker)c, theme);
            }

            foreach (Control child in c.Controls)
            {
                UseTheme(child, theme);
            }
        }

        private static void ApplyTheme(TextBox c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(Label c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(Form c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            c.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            c.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            c.ShowInTaskbar = false;
        }

        private static void ApplyTheme(GroupBox c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(Button c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(RadioButton c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(CheckBox c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(ComboBox c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(DataGridView c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            if (theme == ThemeStyle.Metro)
            {
                #region [Metro]

                DataGridViewCellStyle columnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219))))),
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                    SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247))))),
                    SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17))))),
                    WrapMode = System.Windows.Forms.DataGridViewTriState.True
                };
                c.ColumnHeadersDefaultCellStyle = columnHeadersDefaultCellStyle;

                DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136))))),
                    SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247))))),
                    SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17))))),
                    WrapMode = System.Windows.Forms.DataGridViewTriState.False
                };
                c.DefaultCellStyle = defaultCellStyle;

                DataGridViewCellStyle rowHeadersDefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219))))),
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel),
                    ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                    SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247))))),
                    SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17))))),
                    WrapMode = System.Windows.Forms.DataGridViewTriState.True
                };
                c.RowHeadersDefaultCellStyle = rowHeadersDefaultCellStyle;

                c.AllowUserToResizeRows = false;
                c.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                c.BorderStyle = System.Windows.Forms.BorderStyle.None;
                c.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
                c.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                c.Dock = System.Windows.Forms.DockStyle.Fill;
                c.EnableHeadersVisualStyles = false;
                c.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                c.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                c.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                c.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                c.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                #endregion [Metro]

            }

            else if (theme == ThemeStyle.Perseo)
            {
                #region [Perseo]

                DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                };

                DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                };

                /// <summary>
                /// Cabecera de las grillas
                /// </summary>
                DataGridViewCellStyle columnHeaderCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
                    Font = new Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0)),
                    ForeColor = SystemColors.ControlLightLight,
                    SelectionBackColor = SystemColors.Highlight,
                    SelectionForeColor = SystemColors.HighlightText,
                    WrapMode = DataGridViewTriState.True
                };

                /// <summary>
                /// Estilo de las celdas por defecto
                /// </summary>
                DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.SystemColors.ControlLightLight,
                    Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0)),
                    ForeColor = System.Drawing.SystemColors.ControlText,
                    SelectionBackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
                    SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                    WrapMode = System.Windows.Forms.DataGridViewTriState.False
                };

                /// <summary>
                /// Estilo del rowheader
                /// </summary>
                DataGridViewCellStyle rowHeaderCellStyle = new DataGridViewCellStyle
                {
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight,
                    BackColor = System.Drawing.Color.Lavender,
                    Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0)),
                    ForeColor = System.Drawing.SystemColors.WindowText,
                    SelectionBackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
                    SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                    WrapMode = System.Windows.Forms.DataGridViewTriState.True
                };

                c.AllowUserToAddRows = true;
                c.AllowUserToDeleteRows = true;
                c.AllowUserToResizeRows = false;
                c.AllowUserToResizeColumns = true;
                c.AutoGenerateColumns = false;
                c.Dock = DockStyle.Fill;
                c.MultiSelect = true;
                c.ReadOnly = false;
                c.SelectionMode = DataGridViewSelectionMode.CellSelect;
                c.ShowCellToolTips = false;

                c.BackgroundColor = System.Drawing.SystemColors.Window;
                c.BorderStyle = System.Windows.Forms.BorderStyle.None;

                // Format columnheader
                c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                c.ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;
                c.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                //dataGridView.ColumnHeadersHeight = 32;

                // Format rowheader
                c.RowHeadersVisible = true;
                c.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                c.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                c.RowHeadersDefaultCellStyle = rowHeaderCellStyle;
                c.TopLeftHeaderCell.Value = "Nro ";
                c.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                c.DefaultCellStyle = defaultCellStyle;
                c.EnableHeadersVisualStyles = false;
                c.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
                c.Font = columnHeaderCellStyle.Font;

                #endregion [Perseo]

            }
        }

        private static void ApplyTheme(MenuStrip c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(ToolStrip c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(StatusBar c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(NumericUpDown c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private static void ApplyTheme(DateTimePicker c, ThemeStyle theme)
        {
            c.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}