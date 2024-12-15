using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Infrastructure.Database.Seeding;

internal class UserCapacityInit
{
    public List<IdentityUserRole<int>> GetRolesForAdmin()
    {
        List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
        {
            new IdentityUserRole<int>()
            {
                UserId = 1,
                RoleId = 1
            },
            new IdentityUserRole<int>()
            {
                UserId = 1,
                RoleId = 2
            },
            new IdentityUserRole<int>()
            {
                UserId = 1,
                RoleId = 3
            }
        };
        return adminUserRoles;
    }
    public List<IdentityUserRole<int>> GetRolesForDoctor()
    {
        List<IdentityUserRole<int>> doctorUserRoles = new List<IdentityUserRole<int>>()
        {
            new IdentityUserRole<int>()
            {
                UserId = 2,
                RoleId = 2
            },
            new IdentityUserRole<int>()
            {
                UserId = 2,
                RoleId = 3
            }
        };
        return doctorUserRoles;
    }
}