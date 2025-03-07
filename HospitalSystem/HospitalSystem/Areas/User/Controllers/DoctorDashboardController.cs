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

            return View();
        }

        // 2) Seznam appointmentů (všechny od pacientů)
        [HttpGet]
        public async Task<IActionResult> Appointments()
        {
            var appointments = await _doctorService.GetAllPatientAppointmentsAsync();
            var patients = await _doctorService.GetAllPatientsAsync();

            ViewBag.Patients = patients;
            return View(appointments);
        }
        
        [HttpGet]
        public async Task<IActionResult> TestAppointments()
        {
            var appointments = await _doctorService.GetAllPatientAppointmentsAsync();
            return Content($"Nalezeno: {appointments.Count} registrací.");
        }

        [HttpPost]
        public IActionResult UpdateAppointmentDate(int registrationId, DateTime newDate)
        {
            _doctorService.UpdateAppointmentDateAsync(registrationId, newDate);
            return RedirectToAction("Appointments");
        }
        
        [HttpPost]
        public IActionResult CompleteAppointment(int registrationId, string resultMessage)
        {
            _doctorService.CompleteAppointmentAsync(registrationId, resultMessage);
            return RedirectToAction("Appointments");
        }
        
        [HttpPost]
        public IActionResult DeleteAppointment(int registrationId)
        {
            _doctorService.DeleteAppointmentAsync(registrationId);
            return RedirectToAction("Appointments");
        }

    }
}