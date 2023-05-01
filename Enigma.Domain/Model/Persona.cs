using Enigma.Domain.Base;

namespace Enigma.Domain.Model;

[BsonCollection("Persona", "Planilla")]
public class Persona //: Document
{
    public int? PersonaId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string DNI { get; set; } = null!;
    public DateTime? FecNac { get; set; }
    public bool? IsPerNat { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string RUC { get; set; } = null!;
}