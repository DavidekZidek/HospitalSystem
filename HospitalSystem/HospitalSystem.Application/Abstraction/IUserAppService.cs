using System.Threading.Tasks;
using HospitalSystem.Infrastructure.Identity;

namespace HospitalSystem.Application.Abstraction
{
    public interface IUserAppService
    {
        Task<User> GetCurrentUserAsync(int userId); // Načtení uživatele podle ID
        Task<bool> UpdateUserAsync(User user); // Aktualizace uživatele
        Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword); // Změna hesla
        Task<bool> DeleteUserAsync(int userId); // Smazání uživatele podle ID
        Task LogoutDashboard(); // Odhlášení uživatele a návrat na hlavní stránku
    }
}