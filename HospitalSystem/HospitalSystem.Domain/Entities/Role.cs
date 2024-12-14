namespace HospitalSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Role")]
public class Role : Entity<int>
{
    public string RoleName { get; set; } // Název role

    // Navigační vlastnost
    public ICollection<UserAccount> UserAccounts { get; set; }
}