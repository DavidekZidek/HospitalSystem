namespace HospitalSystem.Domain.Entities;

public class Role
{
    public int ID_role { get; set; }
    public string Role_name { get; set; }

    // Navigation Property
    public ICollection<UserAccount> UserAccounts { get; set; }
}
