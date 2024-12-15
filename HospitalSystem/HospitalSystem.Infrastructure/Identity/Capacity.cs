using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Infrastructure.Identity;

/// <summary>
/// Our Role class which can be modified
/// </summary>
public class Capacity : IdentityRole<int>
{
    public Capacity(string role) : base(role)
    {
    } 
    
    public Capacity() : base()
    {
    }
}