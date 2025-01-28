using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Application.Abstraction
{
    public interface IUserManagementService
    {
        Task<List<User>> GetAllUsersAsync(); // Načte všechny uživatele
        Task<User> GetUserByIdAsync(string userId); // Načte konkrétního uživatele
        Task<bool> DeleteUserAsync(string userId); // Smaže uživatele podle ID
        Task<List<string>> GetUserRolesAsync(string userId); // Načte všechny role uživatele
        Task<bool> AddUserToRoleAsync(string userId, string role); // Přidá uživatele do role
        Task<bool> RemoveUserFromRoleAsync(string userId, string role); // Odebere uživatele z role
        Task<List<User>> GetAllDoctorsAsync();
    }
}