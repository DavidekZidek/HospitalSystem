using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Infrastructure.Database.Seeding;

public static class RoleInit
{
    public static IEnumerable<Role> GetRoles()
    {
        return new List<Role>
        {
            new Role { Id = 1, RoleName = "Admin" },
            new Role { Id = 2, RoleName = "Doctor" },
            new Role { Id = 3, RoleName = "Patient" }
        };
    }
}