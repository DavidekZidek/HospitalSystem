using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Abstraction;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminDashboardController : Controller
{
    private readonly IAccountService _accountService;

    public AdminDashboardController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(); // Načte Index.cshtml
    }
    
    [HttpGet]
    public IActionResult Doctors()
    {
        return View(); // Načte Doctors.cshtml
    }

    [HttpGet]
    public IActionResult Users()
    {
        return View(); // Načte Users.cshtml
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _accountService.Logout(); // Volá metodu Logout v _accountService
        return RedirectToAction("Login", "Account", new { area = "Security" }); // Přesměrování na přihlašovací stránku
    }
}