using System;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public class TabNextControl
    {
        /// <summary>
        /// Enfoca el control hacia el siguiente control de acuerdo a TabIndex, teniendo en cuenta que no se encuentre inactivo, oculto, readonly, etc.
        /// </summary>
        /// <param name="sender">Control desde el que se realiza la acción, para tenerlo como base para pasar al control siguiete</param>
        /// <param name="e"></param>
        public static void GoNextControl(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Al presionar enter, saltar al siguiente control
            if (e.KeyChar == (char)13 && sender != null)
            {
                GoNextControl(sender);
            }
        }

        /// <summary>
        /// Enfoca el control hacia el siguiente control de acuerdo a TabIndex, teniendo en cuenta que no se encuentre inactivo, oculto, readonly, etc.
        /// </summary>
        /// <param name="sender">Control desde el que se realiza la acción, para tenerlo como base para pasar al control siguiete</param>
        public static void GoNextControl(object sender)
        {
            try
            {
                //control pivot, con el que se comienza la busqueda
                Control controlSiguiente = (Control)sender;

                if (controlSiguiente != null)
                {
                    Form formulario = controlSiguiente.FindForm();
                    bool keepSearching = false;
                    do
                    {
                        //Buscar el siguiente control disponible
                        object pri = controlSiguiente;
                        bool result = formulario.SelectNextControl(controlSiguiente, true, true, true, false);

                        if (controlSiguiente == null || result == false)
                        {
                            return;
                        }
                        if (controlSiguiente is TextBox)
                            keepSearching = ((TextBox)controlSiguiente).Visible == false || ((TextBox)controlSiguiente).ReadOnly == true;
                        else if (controlSiguiente is ComboBox)
                            keepSearching = ((ComboBox)controlSiguiente).Visible == false;
                        else if (controlSiguiente is GroupBox)
                            keepSearching = true;
                        else if (controlSiguiente is ToolStrip)
                            keepSearching = false;
                        else if (controlSiguiente is DataGridView)
                            keepSearching = true;
                        else if (controlSiguiente.Visible == true && controlSiguiente.Enabled == true)
                            keepSearching = false;
                        else
                        {
                            MessageDlg.ShowError("Control no definido", "");
                        }
                        //buscar hasta q se encuentre un control q sea visible y activo
                        if (object.ReferenceEquals(pri, controlSiguiente))
                        {
                            keepSearching = false;
                        }
                    }
                    while (keepSearching);
                    formulario.ActiveControl.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}