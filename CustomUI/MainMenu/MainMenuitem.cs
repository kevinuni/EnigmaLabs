using System;
using System.Collections;

namespace Enigma.ControlsUI
{
    public class MainMenuitem
    {
        public int? Codmenuitem { get; set; }

        public Guid? Bkey { get; set; }

        public string FormName { get; set; }

        public string Name { get; set; }

        public int? Codmenuitempadre { get; set; }

        public int? Orden { get; set; }

        public int? Modopresentacion { get; set; }

        public Hashtable m_hsMenuItem = new Hashtable();

        public MainMenuitem this[int? orden]
        {
            get
            {
                return (MainMenuitem)this.m_hsMenuItem[orden];
            }
        }

        public void loadMenuitemTree(ArrayList arr_bcMenuitem)
        {
            foreach (MainMenuitem bcMenuitemhijo in arr_bcMenuitem)
            {
                if (bcMenuitemhijo.Codmenuitempadre == this.Codmenuitem)
                {
                    m_hsMenuItem.Add(bcMenuitemhijo.Orden, bcMenuitemhijo);
                    ArrayList arrInner = (ArrayList)arr_bcMenuitem.Clone();
                    arrInner.Remove(bcMenuitemhijo);
                    bcMenuitemhijo.loadMenuitemTree(arrInner);
                }
            }
        }
    }
}