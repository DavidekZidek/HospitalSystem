using System.Security.Claims;
using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Application.Abstraction;

public interface ISecurityService
{
    Task<User> FindUserByUsername(string username);
    Task<User> FindUserByEmail(string email);
    Task<IList<string>> GetUserRoles(User user);
    Task<User> GetCurrentUser(ClaimsPrincipal principal);
}