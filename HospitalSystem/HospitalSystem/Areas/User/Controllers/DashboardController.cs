using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalSystem.Application.Abstraction;

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
                return RedirectToAction("Login", "Account", new { area = "" });
        
            var appointments = _appointmentService.GetRegistrationsForUser(userId.Value);
            return View(appointments);
        }
        
        [HttpPost]
        public IActionResult BookAppointment(string procedureType, DateTime executionDate)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account", new { area = "" });

            // Jediný krok: zaregistruj uživatele pro HealthAction (ať se to v servisu postará o oboje)
            _appointmentService.RegisterUserForHealthAction(
                userId.Value, 
                procedureType, 
                executionDate);

            // Přesměrovat na seznam
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout(); // Odhlášení uživatele
            return RedirectToAction("Index", "Home", new { area = "" }); // Přesměrování na hlavní stránku
        }
    }
}
