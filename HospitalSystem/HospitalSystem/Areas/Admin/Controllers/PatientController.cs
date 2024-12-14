using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Infrastructure.Database;
using HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly HospitalSystemDbContext _context;

        public PatientController(HospitalSystemDbContext context)
        {
            _context = context;
        }

        // Akce pro zobrazení seznamu pacientů včetně jejich osobních informací
        public IActionResult Index()
        {
            // Načítání pacientů včetně propojené osoby (Person)
            var patients = _context.Patients.Include(p => p.Person).ToList();
            return View(patients); // Předává seznam pacientů do view
        }

        // Akce pro zobrazení detailu konkrétního pacienta včetně jeho osobních údajů
        public IActionResult Details(int id)
        {
            // Načítání detailů pacienta včetně propojené osoby (Person)
            var patient = _context.Patients.Include(p => p.Person)
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(); // Pokud pacient neexistuje, vrátí 404
            }

            return View(patient); // Předává konkrétního pacienta do view
        }
    }
}