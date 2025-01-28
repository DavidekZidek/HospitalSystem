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
            new UserAccount { Id = 7, Name = "PatientJane", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 8, Name = "PatientJames", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 9, Name = "PatientLily", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 10, Name = "PatientOliver", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 11, Name = "PatientEmma", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 12, Name = "PatientLucas", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 13, Name = "PatientAva", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 14, Name = "PatientEthan", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 15, Name = "PatientMia", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 16, Name = "PatientNoah", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 17, Name = "PatientIsabella", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 18, Name = "PatientMason", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 19, Name = "PatientAmelia", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 20, Name = "PatientAlexander", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 21, Name = "PatientCharlotte", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 },
            new UserAccount { Id = 22, Name = "PatientBenjamin", Password = "Patient123", CreatedAt = DateTime.Now, RoleId = 3 }
        };
    }
}