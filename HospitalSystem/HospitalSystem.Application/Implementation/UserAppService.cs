using System.Threading.Tasks;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Infrastructure.Database;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

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
            var userToUpdate = await _dbContext.Users.FindAsync(updatedUser.Id);
            if (userToUpdate == null) return false;

            userToUpdate.UserName = updatedUser.UserName;
            userToUpdate.NormalizedUserName = updatedUser.UserName.ToUpper(); // Zajištění velkých písmen
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.PhoneNumber = updatedUser.PhoneNumber;

            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null) return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(int userId, string currentPassword, string newPassword, string repeatedPassword)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return (false, "User not found.");

            var passwordHasher = new PasswordHasher<User>();

            // Ověření aktuálního hesla
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currentPassword);
            if (verificationResult == PasswordVerificationResult.Failed)
                return (false, "Current password is incorrect.");

            // Ověření, zda nová hesla souhlasí
            if (newPassword != repeatedPassword)
                return (false, "Passwords don't match!");

            // Hashování nového hesla
            user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return (true, "Password changed successfully.");
        }

    }
}
