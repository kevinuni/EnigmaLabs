using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ConsoleTest.TestWialonApi
{
    public class Notification
    {
        /// <summary>
        /// IdHorario
        /// </summary>
        [JsonPropertyName("tid")]
        public int tid { get; set; }

        /// <summary>
        /// Ubicacion
        /// </summary>
        [JsonPropertyName("pos")]
        public Pos pos { get; set; }

        /// <summary>
        /// Unidad
        /// </summary>
        [JsonPropertyName("u")]
        public long u { get; set; }

        /// <summary>
        /// Rutina
        /// </summary>
        [JsonPropertyName("rid")]
        public long rid { get; set; }

        /// <summary>
        /// TipoEvento
        /// </summary>
        [JsonPropertyName("tp")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumTipoEvento tp { get; set; }

        /// <summary>
        /// IndiceParada
        /// </summary>
        [JsonPropertyName("i")]
        public decimal i { get; set; }

        /// <summary>
        /// MarcaTiempo
        /// </summary>
        [JsonPropertyName("tm")]
        public long tm { get; set; }

        [JsonPropertyName("r")]
        public int r { get; set; }
    }
}
