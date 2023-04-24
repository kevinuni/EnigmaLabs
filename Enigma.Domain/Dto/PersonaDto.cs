namespace Enigma.Domain.Dto;

public class PersonaDto
{
    public string Bkey { get; set; } = null!;
    //public int? PersonId { get; set; }
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;
    public string DNI { get; set; } = null!;    
}