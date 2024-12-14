using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database.Seeding;

public static class UserAccountInit
{
    public static IEnumerable<UserAccount> GetUserAccounts()
    {
        return new List<UserAccount>
        {
            new UserAccount { Id = 1, Name = "Admin", Password = "admin123", CreatedAt = DateTime.Now, RoleId = 1 },
            new UserAccount { Id = 2, Name = "DoctorJohn", Password = "doctor123", CreatedAt = DateTime.Now, RoleId = 2 },
            new UserAccount { Id = 3, Name = "PatientJane", Password = "patient123", CreatedAt = DateTime.Now, RoleId = 3 }
        };
    }
}