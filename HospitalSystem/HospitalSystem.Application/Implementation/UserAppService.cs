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
        private readonly SignInManager<User> _signInManager;

        public UserAppService(HospitalSystemDbContext dbContext, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public async Task<User> GetCurrentUserAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(User updatedUser)
        {
            var userToUpdate = await _dbContext.Users.FindAsync(updatedUser.Id);
            if (userToUpdate == null) return false;

            userToUpdate.PhoneNumber = updatedUser.PhoneNumber;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.UserName = updatedUser.UserName;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null || user.PasswordHash != currentPassword) return false;

            user.PasswordHash = newPassword;
            _dbContext.Users.Update(user);
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

        public async Task LogoutDashboard()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
