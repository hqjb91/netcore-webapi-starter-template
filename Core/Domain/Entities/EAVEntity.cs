using System.ComponentModel.DataAnnotations;

namespace Domain;
public class EAVEntity // Parent Entity mapped to a user defined table
{
    [Key]
    public long Id { get; set; } // Primary Key for the Entity
    public string Name { get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    // Optional Collection Navigation to reference dependent entities
    public ICollection<EAVAttribute> EAVAttributes { get; set; } = new List<EAVAttribute>(); 
}