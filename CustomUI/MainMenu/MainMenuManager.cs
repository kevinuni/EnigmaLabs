using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public class MainMenuManager
    {
        public const int MODOPRESENTACION_NUEVO = 1;
        public const int MODOPRESENTACION_EDICION = 2;
        public const int MODOPRESENTACION_SELECCION = 3;
        public const int MODOPRESENTACION_VISUALIZACION = 4;
        public const string MENUITEM_FRMNAME_SEPARADOR = "MENUITEM_FRMNAME_SEPARADOR";

        /// <summary>
        /// Devuelve un ToolStripMenuItem con todos los items que se encuentran dentro de bcMenuitem
        /// </summary>
        /// <param name="bcMenuitem"></param>
        /// <returns></returns>
        public static MainToolStripMenuItem GeneraToolStripMenuItem(MainMenuitem bcMenuitem)
        {
            MainToolStripMenuItem tlsMenu = new MainToolStripMenuItem();
            tlsMenu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tlsMenu.Name = bcMenuitem.Name;
            tlsMenu.Text = bcMenuitem.Name;
            tlsMenu.CurrMenuitem = bcMenuitem;
            if (bcMenuitem.m_hsMenuItem.Count == 0)
            {
                //solamente añadir un evento cuando no tenga hijos, es decir sea un detalle
                tlsMenu.Click += new EventHandler(ActivateForm);
            }

            // Sort child nodes
            List<MainMenuitem> listOfMenuitem = new List<MainMenuitem>();
            foreach (MainMenuitem bcMenuitemHijo in bcMenuitem.m_hsMenuItem.Values)
            {
                listOfMenuitem.Add(bcMenuitemHijo);
            }
            listOfMenuitem.Sort
            (
                delegate (MainMenuitem objX, MainMenuitem objY)
                {
                    return objX.Orden.Value.CompareTo(objY.Orden.Value);
                }
            );

            foreach (MainMenuitem bcMenuitemHijo in listOfMenuitem)
            {
                if (bcMenuitemHijo.Name.Trim() == MENUITEM_FRMNAME_SEPARADOR.Trim())
                {
                    tlsMenu.DropDownItems.Add(new ToolStripSeparator());
                }
                else
                {
                    tlsMenu.DropDownItems.Add(GeneraToolStripMenuItem(bcMenuitemHijo));
                }
            }
            return tlsMenu;
        }

        public static List<MainMenuitem> Preprocesar(ArrayList arr_bcMenuitem)
        {
            //Obtener el nodo raiz
            MainMenuitem bcMenuitemRootNode = null;

            foreach (MainMenuitem bcMenuitem in arr_bcMenuitem)
            {
                if (bcMenuitem.Codmenuitempadre.HasValue == false)
                {
                    bcMenuitemRootNode = bcMenuitem;
                }
            }

            arr_bcMenuitem.Remove(bcMenuitemRootNode);

            //carga el arbol
            bcMenuitemRootNode.loadMenuitemTree(arr_bcMenuitem);

            // Ordenar arbol
            List<MainMenuitem> list = new List<MainMenuitem>();
            foreach (MainMenuitem bcMenuitemHijo in bcMenuitemRootNode.m_hsMenuItem.Values)
            {
                list.Add(bcMenuitemHijo);
            }
            list.Sort
            (
                delegate (MainMenuitem objX, MainMenuitem objY)
                {
                    return objX.Orden.Value.CompareTo(objY.Orden.Value);
                }
            );

            return list;
        }

        /// <summary>
        /// Mostrar un formulario
        /// </summary>
        /// <param name="form">Formulario a mostrar</param>
        /// <param name="sender">Formulario padre</param>
        /// <returns></returns>
        public static DialogResult Mostrar(Form form, object sender, bool ismodal)
        {
            if (ismodal)
            {
                if (form.IsMdiChild)
                {
                    throw new Exception("Una ventana modal no puede tener MdiParent. (code: m580SM9w)");
                }
                return form.ShowDialog();
            }
            if (sender is Form && ((Form)sender).Modal)
            {
                if (form.IsMdiChild)
                {
                    throw new Exception("Una ventana modal no puede tener MdiParent. (code: YZToo9gj)");
                }
                return form.ShowDialog();
            }
            else
            {
                form.MdiParent = MdiSingleton.Instance().MdiForm;
                form.StartPosition = FormStartPosition.Manual;
                form.Show();
                return DialogResult.None;
            }
        }

        /// <summary>
        /// Lanzar un formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ActivateForm(object sender, EventArgs e)
        {
            MainToolStripMenuItem menu = (MainToolStripMenuItem)sender;

            int? modopresentacion = menu.CurrMenuitem.Modopresentacion;
            string vNamespace = Constantes.NAMESPACE;
            string vClassname = ((MainMenuitem)menu.CurrMenuitem).FormName;
            string vAssemblyName = Constantes.ASSEMBLYNAME;

            string typeName = string.Format("{0}.{1},{2}", vNamespace, vClassname, vAssemblyName);

            Type type = Type.GetType(typeName);

            if (type != null)
            {
                ArrayList arr = new ArrayList();

                if (modopresentacion.HasValue && modopresentacion.Value == MODOPRESENTACION_NUEVO)
                {
                    arr.Add(CustomForm.FORM_MODE.New);
                }
                else if (modopresentacion.HasValue && modopresentacion.Value == MODOPRESENTACION_EDICION)
                {
                    arr.Add(CustomForm.FORM_MODE.Edition);
                }
                else if (modopresentacion.HasValue && modopresentacion.Value == MODOPRESENTACION_SELECCION)
                {
                    arr.Add(CustomForm.FORM_MODE.Selection);
                }
                else if (modopresentacion.HasValue && modopresentacion.Value == MODOPRESENTACION_VISUALIZACION)
                {
                    arr.Add(CustomForm.FORM_MODE.Visualization);
                }

                Object remoteObj = Activator.CreateInstance(type, arr.ToArray());
                Mostrar((Form)remoteObj, sender, false);
            }
        }
    }
}