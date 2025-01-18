using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Infrastructure.Database;

namespace HospitalSystem.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly HospitalSystemDbContext _dbContext;

        public DashboardController(HospitalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var patients = _dbContext.Patients
                .Include(p => p.Person)
                .ToList();

            var persons = _dbContext.Persons.ToList();
            var healthInsuranceCount = _dbContext.Patients
                .Select(p => p.HealthInsurance)
                .Distinct()
                .Count();

            var patientCount = _dbContext.Patients.Count();
            var healthActionCount = _dbContext.HealthActions.Count();
            var doctorCount = _dbContext.Doctors.Count();

            ViewBag.Persons = persons;
            ViewBag.HealthInsuranceCount = healthInsuranceCount;
            ViewBag.PatientCount = patientCount;
            ViewBag.HealthActionCount = healthActionCount;
            ViewBag.DoctorCount = doctorCount;

            return View(patients);
        }
    }
}