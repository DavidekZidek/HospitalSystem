using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalSystem.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;

public class DoctorDashboardControler : Controller
{
    [Area("User")]
    [Authorize(Roles="Doctor")]
    public class DoctorDashboardController : Controller
    {
        private readonly IDoctorAppointmentService _doctorService;
        private readonly IUserAppService _userAppService;
        private readonly IAccountService _accountService;

        public DoctorDashboardController(IDoctorAppointmentService doctorService, IUserAppService userAppService, IAccountService accountService)
        {
            _doctorService = doctorService;
            _userAppService = userAppService;
            _accountService = accountService;
        }

        private int? GetUserId()
        {
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(claim, out var id) ? id : null;
        }

        // 1) Dashboard (Index) - detail doktora, apod.
        [HttpGet]
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

            // Vrací "Areas/User/Views/DoctorDashboard/Index.cshtml" (dle konvencí)
            return View();
        }

        // 2) Seznam appointmentů (všechny od pacientů)
        [HttpGet]
        public IActionResult Appointments()
        {
            var appointments = _doctorService.GetAllPatientAppointments();
            return View(appointments); 
            // => "Areas/User/Views/DoctorDashboard/Appointments.cshtml"
        }

        [HttpPost]
        public IActionResult UpdateAppointmentDate(int registrationId, DateTime newDate)
        {
            _doctorService.UpdateAppointmentDate(registrationId, newDate);
            return RedirectToAction("Appointments");
        }

        [HttpPost]
        public IActionResult CompleteAppointment(int registrationId, string resultMessage)
        {
            _doctorService.CompleteAppointment(registrationId, resultMessage);
            return RedirectToAction("Appointments");
        }

        [HttpPost]
        public IActionResult DeleteAppointment(int registrationId)
        {
            _doctorService.DeleteAppointment(registrationId);
            return RedirectToAction("Appointments");
        }

        // Případně Logout, atd.
    }
}