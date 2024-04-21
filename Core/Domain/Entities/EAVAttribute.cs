using System.ComponentModel.DataAnnotations;

namespace Domain;
public class EAVAttribute // Attribute Entity mapped to user defined columns
{
    [Key]
    public long Id { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public long EAVEntityId { get; set; } // Required foreign key property
    public EAVEntity EAVEntity { get; set; } = null!; // Required reference navigation to parent entity
    public ICollection<EAVValue> EAVValues{ get; set; } = new List<EAVValue>();
}