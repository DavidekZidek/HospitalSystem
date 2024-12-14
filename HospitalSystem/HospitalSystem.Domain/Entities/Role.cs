namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Role")]
public class Role
{
    public int ID_role { get; set; }
    public string Role_name { get; set; }

    // Navigation Property
    public ICollection<UserAccount> UserAccounts { get; set; }
}
