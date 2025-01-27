using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Abstraction;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalSystem.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly IUserAppService _userAppService;

        public DashboardController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        private int? GetUserId()
        {
            // Načtení ID přihlášeného uživatele z claimů
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "" });

            var user = await _userAppService.GetCurrentUserAsync(userId.Value);
            if (user == null)
                return RedirectToAction("Login", "Account", new { area = "" });

            ViewBag.UserId = user.Id;
            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            ViewBag.PhoneNumber = user.PhoneNumber;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(int userId, string userName, string email, string phoneNumber)
        {
            if (userId <= 0)
            {
                TempData["Error"] = "Invalid user ID.";
                return RedirectToAction("Index");
            }

            var updatedUser = new Infrastructure.Identity.User
            {
                Id = userId,
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            var success = await _userAppService.UpdateUserAsync(updatedUser);
            TempData[success ? "Message" : "Error"] = success
                ? "Profile updated successfully."
                : "Failed to update profile.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(int userId, string currentPassword, string newPassword)
        {
            if (userId <= 0)
            {
                TempData["Error"] = "Invalid user ID.";
                return RedirectToAction("Index");
            }

            var success = await _userAppService.UpdatePasswordAsync(userId, currentPassword, newPassword);
            TempData[success ? "Message" : "Error"] = success
                ? "Password changed successfully."
                : "Failed to change password. Please check your current password.";

            return RedirectToAction("Index");
        }

        public IActionResult Appointments()
        {
            // Zobrazení stránky Appointments
            return View();
        }

        public IActionResult Reports()
        {
            // Zobrazení stránky Reports
            return View();
        }

        public IActionResult Settings()
        {
            // Zobrazení stránky Settings
            return View();
        }

        public IActionResult Logout()
        {
            // Odhlášení uživatele a přesměrování na přihlašovací stránku
            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}
