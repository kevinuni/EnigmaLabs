using Enigma.Domain.Base;

namespace Enigma.Domain.Model;

[BsonCollection("Persona", "Planilla")]
public class Persona //: Document
{
    public int? PersonaId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public DateTime? FecNac { get; set; }
    public bool? IsPerNat { get; set; }
    public string RazonSocial { get; set; }
    public string RUC { get; set; }
}