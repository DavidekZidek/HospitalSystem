using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAccountService _accountService;

        public DashboardController(IUserAppService userAppService, IAppointmentService appointmentService, IAccountService accountService)
        {
            _userAppService = userAppService;
            _appointmentService = appointmentService;
            _accountService = accountService;
        }

        private int? GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            var user = await _userAppService.GetCurrentUserAsync(userId.Value);
            if (user == null)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            ViewBag.UserName = user.UserName;
            ViewBag.FirstName = user.FirstName; // Přidáno
            ViewBag.LastName = user.LastName;   // Přidáno
            ViewBag.Email = user.Email;
            ViewBag.PhoneNumber = user.PhoneNumber;

            return View();
        }


        public IActionResult Reports()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Appointments()
        {
            var userId = GetUserId();
            TempData["TestUserId"] = userId.HasValue ? userId.Value.ToString() : "(null)";
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            var appointments = _appointmentService.GetRegistrationsForUser(userId.Value);
            return View(appointments);
        }

        [HttpPost]
        public IActionResult BookAppointment(string procedureType, DateTime executionDate)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            _appointmentService.RegisterUserForHealthAction(
                userId.Value,
                procedureType,
                executionDate);

            return RedirectToAction("Appointments");
        }

        [HttpPost]
        public IActionResult CancelAppointment(int registrationId)
        {
            _appointmentService.DeleteRegistration(registrationId);
            return RedirectToAction("Appointments");
        }

        public IActionResult Settings()
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            var user = _userAppService.GetCurrentUserAsync(userId.Value).Result;
            if (user == null)
                return RedirectToAction("Login", "Account", new { area = "Security" });

            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            ViewBag.PhoneNumber = user.PhoneNumber;
            ViewBag.UserId = user.Id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsername(int userId, string userName)
        {
            if (string.IsNullOrEmpty(userName) || userName.Length < 3)
            {
                TempData["ErrorMessage"] = "Username must be at least 3 characters long.";
                return RedirectToAction("Settings");
            }

            var user = await _userAppService.GetCurrentUserAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Settings");
            }

            user.UserName = userName;
            user.NormalizedUserName = userName.ToUpper();

            var result = await _userAppService.UpdateUserAsync(user);

            TempData[result ? "SuccessMessage" : "ErrorMessage"] = result
                ? "Username updated successfully."
                : "Failed to update username.";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmail(int userId, string email)
        {
            if (string.IsNullOrEmpty(email) || !new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email))
            {
                TempData["ErrorMessage"] = "Invalid email format.";
                return RedirectToAction("Settings");
            }

            var user = await _userAppService.GetCurrentUserAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Settings");
            }

            user.Email = email;

            var result = await _userAppService.UpdateUserAsync(user);

            TempData[result ? "SuccessMessage" : "ErrorMessage"] = result
                ? "Email updated successfully."
                : "Failed to update email.";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> UpdatePhoneNumber(int userId, string phoneNumber)
        {
            // Validace: Zkontrolujte, zda telefonní číslo není prázdné, má alespoň 9 znaků a obsahuje pouze čísla.
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 9 || !phoneNumber.All(char.IsDigit))
            {
                TempData["ErrorMessage"] = "Phone number must be at least 9 digits long and contain only numbers.";
                return RedirectToAction("Settings");
            }

            var user = await _userAppService.GetCurrentUserAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Settings");
            }

            user.PhoneNumber = phoneNumber;

            var result = await _userAppService.UpdateUserAsync(user);

            TempData[result ? "SuccessMessage" : "ErrorMessage"] = result
                ? "Phone number updated successfully."
                : "Failed to update phone number.";
            return RedirectToAction("Settings");
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(int userId, string currentPassword, string newPassword, string repeatedPassword)
        {
            if (newPassword != repeatedPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match.";
                return RedirectToAction("Settings");
            }

            var (success, message) = await _userAppService.ChangePasswordAsync(
                userId,
                currentPassword,
                newPassword,
                repeatedPassword
            );

            TempData[success ? "SuccessMessage" : "ErrorMessage"] = message;
            return RedirectToAction("Settings");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        
        [HttpGet]
        public IActionResult TestRole()
        {
            var allClaims = User.Claims.Select(c => $"{c.Type} = {c.Value}");
            var result = "Tvoje claimy:\n" + string.Join("\n", allClaims);
            return Content(result); // Vrátí raw text
        }
    }
}
