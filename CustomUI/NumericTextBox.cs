using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class NumericTextBox : System.Windows.Forms.TextBox
    {
        #region [Private]

        //NumberFormatInfo numberFormatInfo;
        private string m_DecimalSeparator;

        //        string groupSeparator;
        private string m_NegativeSign;

        /// <summary>
        /// Número de cifras decimales
        /// </summary>
        private int m_NumDecimal;

        /// <summary>
        /// Mostrar decimales
        /// </summary>
        private bool m_AllowDecimal;

        /// <summary>
        /// Permitir números negativos
        /// </summary>
        private bool m_AllowNegative;

        /// <summary>
        /// Autocompletar la cantidad con 0.00 al salir del control
        /// </summary>
        private bool m_AutocompleteZeros;

        #endregion [Private]

        public NumericTextBox()
        {
            InitializeComponent();
        }

        //public void AllowDecimal(bool value)
        //{
        //    m_AllowDecimal = value;
        //}

        //public void NumDecimal(int value)
        //{
        //    m_NumDecimal = value;
        //}

        public int NumDecimal
        {
            get { return m_NumDecimal; }
            set { m_NumDecimal = value; }
        }

        public bool AutocompleteZeros
        {
            get { return m_AutocompleteZeros; }
            set { m_AutocompleteZeros = value; }
        }

        public NumericTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            //Valores iniciales por defecto
            m_DecimalSeparator = ".";
            m_NegativeSign = "-";
            m_NumDecimal = 2;
            m_AllowDecimal = true;
            m_AllowNegative = false;
            m_AutocompleteZeros = false;
            TextAlign = HorizontalAlignment.Right;
        }

        public decimal? ValueDecimal
        {
            get
            {
                decimal? val = new decimal?();
                try
                {
                    val = decimal.Parse(this.Text);
                }
                catch
                {
                    val = new decimal?();
                }
                return val;
            }
        }

        public int? ValueInt32
        {
            get
            {
                int? val = new int?();
                try
                {
                    val = int.Parse(this.Text);
                }
                catch
                {
                    val = new int?();
                }
                return val;
            }
        }

        /// <summary>
        /// Controla el comportamiento del control, al ingresar cada caracter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //IMPORTANTE, la politica del control de caracteres es permitir todos los caracteres excepto los q se niegan explicitamente (e.keychar = '\0')

            TextBox textbox = (TextBox)sender;

            if (this.ReadOnly == true)
                return;

            //tecla presionada
            string keyInput = e.KeyChar.ToString();
            //cadena actual del textbox
            string valorInicial = textbox.Text;

            //posicion del cursor dentro del control
            int posInicialCursor = textbox.SelectionStart;

            //posicion del caracter decimal en el control, caso no exista devuelve -1
            int posDecimal = valorInicial.IndexOf(m_DecimalSeparator);

            if (textbox.SelectionLength > 0)
            {
                //CARACTERES NUMERICOS
                if (Char.IsDigit(e.KeyChar))
                {
                    //elimina los carateres marcados y los reemplaza por la tecla presionada
                    textbox.Text = textbox.Text.Remove(posInicialCursor, textbox.SelectionLength);
                    textbox.SelectionStart = posInicialCursor;
                }
                //si el caracter presionado es el decimal
                else if (keyInput.Equals(m_DecimalSeparator))
                {
                    //si están permitidos los decimales
                    if (m_AllowDecimal && m_NumDecimal > 0)
                    {
                        if (posInicialCursor == 0)
                        {
                            //el decimal solo se puede poner despues del primer caracter
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            //si ya existe el caracter decimal
                            if (valorInicial.IndexOf(e.KeyChar) >= 0)
                            {
                                //si la posicion del cursor se encuentra en la parte decimal
                                if (posInicialCursor > posDecimal)
                                {
                                    e.KeyChar = '\0';
                                }
                                //si el la posicion del cursor se encuentra en la parte entera
                                else
                                {
                                    //->el caracter reemplaza al existente
                                    textbox.Text = textbox.Text.Remove(posInicialCursor);
                                    NumericTextBox_Leave(sender, e);
                                    textbox.SelectionStart = posInicialCursor + 1;
                                    e.KeyChar = '\0';
                                }
                            }
                            //si no existe el caracter decimal aún
                            else
                            {
                                //si el cursor no se encuentr al final de la cadena, poner los ceros (0)
                                if (posInicialCursor < textbox.Text.Length)
                                {
                                    textbox.Text = textbox.Text.Remove(posInicialCursor);
                                    NumericTextBox_Leave(sender, e);
                                    textbox.SelectionStart = posInicialCursor + 1;
                                    e.KeyChar = '\0';
                                }
                            }
                        }
                    }
                    //si no están permitidos los decimales
                    else
                    {
                        e.KeyChar = '\0';
                    }
                }

                //RETROCESO
                else if (e.KeyChar == '\b' || e.KeyChar == '\r')
                {
                    // Backspace key is OK
                }
                else
                {
                    //Swallow this invalid key and beep
                    e.Handled = true;
                }
            }
            else
            {
                //CARACTERES NUMERICOS
                if (Char.IsDigit(e.KeyChar))
                {
                    //si el numero tiene posiciones decimales y el ancho ya se encuentra lleno
                    if (posDecimal >= 0 && valorInicial.Length > posDecimal + m_NumDecimal)
                    {
                        //se está en la parte entera
                        if (posInicialCursor <= posDecimal)
                        {
                            //->permitir el ingreso
                        }
                        //se está en la parte decimal
                        else
                        {
                            //el cursor está en la parte decimal (pero no al final)
                            if (posInicialCursor < valorInicial.Length)
                            {
                                //->el caracter reemplaza al existente
                                textbox.Text = textbox.Text.Remove(posInicialCursor, 1);
                                textbox.SelectionStart = posInicialCursor;
                            }
                            else
                            {
                                //si se está al final de la parte decimal
                                e.KeyChar = '\0';
                            }
                        }
                    }
                }
                //si el caracter presionado es el decimal
                else if (keyInput.Equals(m_DecimalSeparator))
                {
                    //si están permitidos los decimales
                    if (m_AllowDecimal && m_NumDecimal > 0)
                    {
                        //debe existir al menos un caracter en el control
                        if (valorInicial.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }) < 0)
                        {
                            e.KeyChar = '\0';
                        }
                        else if (posInicialCursor == 0)
                        {
                            //el decimal solo se puede poner despues del primer caracter
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            //si ya existe el caracter decimal
                            if (valorInicial.IndexOf(e.KeyChar) >= 0)
                            {
                                //si la posicion del cursor se encuentra en la parte decimal
                                if (posInicialCursor > posDecimal)
                                {
                                    e.KeyChar = '\0';
                                }
                                //si el la posicion del cursor se encuentra en la parte entera
                                else
                                {
                                    //->el caracter reemplaza al existente
                                    textbox.Text = textbox.Text.Remove(posInicialCursor);
                                    NumericTextBox_Leave(sender, e);
                                    textbox.SelectionStart = posInicialCursor + 1;
                                    e.KeyChar = '\0';
                                }
                            }
                            //si no existe el caracter decimal aún
                            else
                            {
                                //si el cursor no se encuentr al final de la cadena, poner los ceros (0)
                                if (posInicialCursor < textbox.Text.Length)
                                {
                                    textbox.Text = textbox.Text.Remove(posInicialCursor);
                                    NumericTextBox_Leave(sender, e);
                                    textbox.SelectionStart = posInicialCursor + 1;
                                    e.KeyChar = '\0';
                                }
                            }
                        }
                    }
                    //si no están permitidos los decimales
                    else
                    {
                        e.KeyChar = '\0';
                    }
                }
                //SIGNO NEGATIVO
                else if (keyInput.Equals(m_NegativeSign) && m_AllowNegative)
                {
                    //si ya ha aparaecido antes
                    if (valorInicial.IndexOf(e.KeyChar) >= 0)
                        e.KeyChar = '\0';
                    else //si no aparece aun solo permitir q aparezca cuando sea el primer caracter
                    {
                        if (valorInicial.Length > 0)
                            e.KeyChar = '\0';
                    }
                }
                //RETROCESO
                else if (e.KeyChar == '\b' || e.KeyChar == '\r')
                {
                    // Backspace key is OK
                }
                else
                {
                    //Swallow this invalid key and beep
                    e.Handled = true;
                }
            }
            TabNextControl.GoNextControl(sender, e);
        }

        /// <summary>
        /// Autocompletar ceros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            ///Posicion del signo decimal
            int posDot = textbox.Text.IndexOf(".");
            if (m_AutocompleteZeros && m_AllowDecimal)
            {
                try
                {
                    if (textbox.Text.Trim() != string.Empty)
                    {
                        //si no tiene el signo decimal
                        if (posDot == -1)
                        {
                            //completar decimal y volver a verificar (para ponerle el 00)
                            textbox.Text += ".";
                            NumericTextBox_Leave(sender, e);
                        }
                        else
                        {
                            textbox.Text = textbox.Text.PadRight(posDot + m_NumDecimal + 1, '0');
                        }
                    }
                    else
                    {
                        //Si el valor es cero -> 0.00
                        textbox.Text = "0.";
                        NumericTextBox_Leave(sender, e);
                    }
                }
                catch
                {
                    //Si el valor es cero -> 0.00
                    textbox.Text = "0.";
                    NumericTextBox_Leave(sender, e);
                }
            }
        }
    }
}