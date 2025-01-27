using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database.Seeding;

public static class UserAccountInit
{
    public static IEnumerable<UserAccount> GetUserAccounts()
    {
        return new List<UserAccount>
        {
            new UserAccount { Id = 1, Name = "Admin", Password = "Admin123", CreatedAt = DateTime.Now, RoleId = 1 },
            new UserAccount { Id = 2, Name = "DoctorJohn", Password = "Doctor123", CreatedAt = DateTime.Now, RoleId = 2 },
            new UserAccount { Id = 3, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 4, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 5, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 6, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 7, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 }
        };
    }
}