using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    [Serializable]
    public class Credencial
    {
        public string Nombre { get; set; }

        public string Empresa { get; set; }

        public string Fingerprint { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string AuthToken { get; set; }

    }
}
