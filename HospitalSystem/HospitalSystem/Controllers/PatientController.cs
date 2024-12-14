using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Infrastructure.Database;
using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalSystemDbContext _dbContext;

        public PatientController(HospitalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Zobrazení seznamu pacientů
        public IActionResult Index()
        {
            var patients = _dbContext.Patients.ToList();
            return View(patients);
        }

        // Formulář pro vytvoření nového pacienta
        public IActionResult Create()
        {
            return View();
        }

        // Uložení nového pacienta
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Patients.Add(patient);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }
    }
}