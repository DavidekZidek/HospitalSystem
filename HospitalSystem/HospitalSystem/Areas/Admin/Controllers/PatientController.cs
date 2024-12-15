using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Infrastructure.Database;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Application.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        IPatientAppService _patientAppService;

        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        // Akce pro zobrazení seznamu pacientů včetně jejich osobních informací
        public IActionResult Index()
        {
            // Načítání pacientů včetně propojené osoby (Person)
            var patients = _patientAppService.Select();
            return View(patients); // Předává seznam pacientů do view
        }

        // Akce pro zobrazení detailu konkrétního pacienta včetně jeho osobních údajů
        public IActionResult Details(int id)
        {
            // Načítání detailů pacienta včetně propojené osoby (Person)
            var patient = _patientAppService.Select()
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(); // Pokud pacient neexistuje, vrátí 404
            }

            return View(patient); // Předává konkrétního pacienta do view
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _patientAppService.Create(patient);

            return RedirectToAction(nameof(PatientController.Index));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _patientAppService.Delete(id);
            
            if (deleted)
            {
                return RedirectToAction(nameof(PatientController.Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
