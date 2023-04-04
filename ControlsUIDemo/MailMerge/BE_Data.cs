using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsUIDemo
{
    public class BE_Data
    {
        public BE_Data(string pNombre, string pApellido, DateTime pFnacimiento, decimal pValor)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            Fnacimiento = pFnacimiento;
            Valor = pValor;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fnacimiento { get; set; }
        public decimal Valor { get; set; }
    }
}
