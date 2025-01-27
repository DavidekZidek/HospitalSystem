using HospitalSystem.Application.Abstraction;
using HospitalSystem.Infrastructure.Database;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly HospitalSystemDbContext _dbContext;

        public UserAppService(HospitalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetCurrentUserAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(User updatedUser)
        {
            try
            {
                // Načtení uživatele z databáze podle ID
                var userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
                if (userToUpdate == null)
                {
                    return false; // Uživatel neexistuje
                }

                // Aktualizace konkrétních vlastností uživatele
                userToUpdate.PhoneNumber = updatedUser.PhoneNumber;
                userToUpdate.Email = updatedUser.Email;
                userToUpdate.UserName = updatedUser.UserName;

                // Uložení změn do databáze
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logování chyby (volitelné)
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            try
            {
                // Načtení uživatele z databáze podle ID
                var user = await _dbContext.Users.FindAsync(userId);
                if (user == null || user.PasswordHash != currentPassword) // Ověření aktuálního hesla
                {
                    return false;
                }

                // Aktualizace hesla
                user.PasswordHash = newPassword;
                _dbContext.Users.Update(user);

                // Uložení změn do databáze
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logování chyby (volitelné)
                Console.WriteLine($"Error updating password: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                // Načtení uživatele z databáze podle ID
                var user = await _dbContext.Users.FindAsync(userId);
                if (user == null)
                {
                    return false;
                }

                // Odstranění uživatele
                _dbContext.Users.Remove(user);

                // Uložení změn do databáze
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logování chyby (volitelné)
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }
    }
}
