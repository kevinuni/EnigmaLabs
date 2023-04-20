using System;
using System.Collections.Generic;

namespace Enigma.Util
{
    [Serializable]
    public class TextFieldParser
    {
        [Serializable]
        public enum CompleteElements
        {
            /// <summary>
            /// Returns as many elements as fileWidths input be
            /// </summary>
            AllElements,

            /// <summary>
            /// Only returns elements who have not null values
            /// </summary>
            OnlyValues
        };

        private int[] m_fieldWidths;
        private string m_line;
        private List<string> m_results;
        private int m_lineWidth;
        public CompleteElements m_CompleteElements;

        public TextFieldParser(string line)
        {
            m_line = line;
            m_lineWidth = m_line.Length;
            m_results = new List<string>();
            m_CompleteElements = CompleteElements.OnlyValues;
        }

        public void SetCompleteElements(CompleteElements value)
        {
            m_CompleteElements = value;
        }

        public void SetFieldWidths(params int[] fileWidths)
        {
            m_fieldWidths = fileWidths;
        }

        public string[] ReadFields()
        {
            int pivot = 0;
            m_results = new List<string>();

            for (int x = 0; x < m_fieldWidths.Length; x++)
            {
                if (pivot + m_fieldWidths[x] <= m_lineWidth)
                {
                    m_results.Add(m_line.Substring(pivot, m_fieldWidths[x]).Trim());
                }
                else if (pivot <= m_lineWidth && pivot + m_fieldWidths[x] > m_lineWidth)
                {
                    // si termina la linea obtener lo que queda de cadena
                    m_results.Add(m_line.Substring(pivot, m_lineWidth - pivot).Trim());
                }
                else
                {
                    // si ya sesobrepasó la cadena, devolver vacio
                    if (m_CompleteElements == CompleteElements.AllElements)
                    {
                        m_results.Add(string.Empty);
                    }
                    else
                    {
                        break;
                    }
                }
                pivot += m_fieldWidths[x];
            }
            return m_results.ToArray();
        }
    }
}