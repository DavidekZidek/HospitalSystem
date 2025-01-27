using HospitalSystem.Infrastructure.Identity;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Abstraction
{
    public interface IUserAppService
    {
        Task<User> GetCurrentUserAsync(int userId); // Načtení uživatele podle ID
        Task<bool> UpdateUserAsync(User user); // Aktualizace uživatele (přezdívka, email, telefonní číslo)
        Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword); // Změna hesla
        Task<bool> DeleteUserAsync(int userId); // Smazání uživatele podle ID
    }
}