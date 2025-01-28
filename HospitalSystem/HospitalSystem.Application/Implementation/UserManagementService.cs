using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HospitalSystem.Application.Implementation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserManagementService> _logger;

        public UserManagementService(UserManager<User> userManager, ILogger<UserManagementService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userId} not found.");
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {user.UserName} deleted successfully.");
            }
            else
            {
                _logger.LogError($"Failed to delete user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            return result.Succeeded;
        }

        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userId} not found.");
                return new List<string>();
            }

            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<bool> AddUserToRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userId} not found.");
                return false;
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {userId} not found.");
                return false;
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }
        
        public async Task<List<User>> GetAllDoctorsAsync()
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            return doctors.ToList();
        }

    }
}
