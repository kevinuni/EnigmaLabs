using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Util
{
    [Serializable]
    public class EventData
    {
        private string m_data;
        public EventData(string data)
        {
            m_data = data;
        }

        public EventData() 
        {
        
        }
    }
}
