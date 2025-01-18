using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;
using HospitalSystem.Infrastructure.Identity.Enums;

namespace HospitalSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Capacitys.Admin) + ", " + nameof(Capacitys.Doctor))]
    public class PatientController : Controller
    {
        private readonly IPatientAppService _patientAppService;
        private readonly DbContext _dbContext; // Přidání DbContextu pro načítání osob

        public PatientController(IPatientAppService patientAppService, DbContext dbContext)
        {
            _patientAppService = patientAppService;
            _dbContext = dbContext;
        }

        // Akce pro zobrazení seznamu pacientů a osob
        public IActionResult Index()
        {
            // Načtení pacientů včetně propojené osoby (Person)
            var patients = _dbContext.Set<Patient>()
                .Include(p => p.Person) // Zahrnutí relace Person
                .ToList();

            // Načtení všech osob
            var persons = _dbContext.Set<Person>().ToList();

            // Odeslání seznamu osob do ViewData
            ViewData["Persons"] = persons;

            // Vrací seznam pacientů do pohledu
            return View(patients);
        }

// Akce pro zobrazení detailu konkrétního pacienta
        public IActionResult Details(int id)
        {
            // Načtení detailů pacienta včetně propojené osoby (Person)
            var patient = _dbContext.Set<Patient>()
                .Include(p => p.Person) // Zahrnutí relace Person
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(); // Pokud pacient neexistuje, vrátí 404
            }

            return View(patient); // Předání pacienta do pohledu
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientAppService.Create(patient);
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _patientAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
