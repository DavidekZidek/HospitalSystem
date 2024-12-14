namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("UserAccounts")]
public class UserAccount : Entity<int>
{
    public int PersonalID { get; set; } // Pokud má specifický účel (např. osobní identifikace)
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign Key
    public int RoleId { get; set; } // Přeznačeno podle konvencí
    public Role Role { get; set; }

    // Navigation Property
    public ICollection<Registration> Registrations { get; set; }
}