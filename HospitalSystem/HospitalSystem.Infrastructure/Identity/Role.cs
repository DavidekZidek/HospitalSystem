using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Infrastructure.Identity;

/// <summary>
/// Our Role class which can be modified
/// </summary>
public class Role : IdentityRole<int>
{
    public Role(string role) : base(role)
    {
    } 
    
    public Role() : base()
    {
    }
}