using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.TestWialonApi
{
    public enum EnumTipoEvento
    {
        [EnumMember(Value = "1")]
        RutaIniciada = 1,

        [EnumMember(Value = "32")]
        LlegadaParada = 32,

        [EnumMember(Value = "128")]
        SalidaParada = 128,

        [EnumMember(Value = "256")]
        ParadaOmitida = 256,

        [EnumMember(Value = "2048")]
        FueraLinea = 2048
    }
}
