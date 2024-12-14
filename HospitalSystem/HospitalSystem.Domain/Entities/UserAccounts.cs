namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("UserAccounts")]
public class UserAccount
{
    public int PersonalID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign Key
    public int ID_role { get; set; }
    public Role Role { get; set; }

    // Navigation Property
    public ICollection<Registration> Registrations { get; set; }
}
