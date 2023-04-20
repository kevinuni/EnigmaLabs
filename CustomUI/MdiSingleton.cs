using System.Windows.Forms;

namespace Enigma.ControlsUI
{
    public class MdiSingleton
    {
        private static MdiSingleton m_Instance;

        public static MdiSingleton Instance()
        {
            if (m_Instance == null)
            {
                m_Instance = new MdiSingleton();
            }
            return m_Instance;
        }

        /// <summary>
        /// Constructor privado para que no se pueda instanciar
        /// </summary>
        private MdiSingleton()
        { }

        private Form m_Mdiform;

        public Form MdiForm
        {
            get { return m_Mdiform; }
            set { m_Mdiform = value; }
        }
    }
}