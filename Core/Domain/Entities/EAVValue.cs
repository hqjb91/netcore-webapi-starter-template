using System.ComponentModel.DataAnnotations;

namespace Domain;
public class EAVValue
{
    [Key]
    public long Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public long EAVAttributeId { get; set; }
    public EAVAttribute EAVAttribute { get; set; } = null!;
}