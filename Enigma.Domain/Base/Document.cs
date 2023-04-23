namespace Enigma.Domain.Base;

public class Document : IDocument
{
    public string CreatedBy { get; set; } = null!;
    public string ModifiedBy { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}