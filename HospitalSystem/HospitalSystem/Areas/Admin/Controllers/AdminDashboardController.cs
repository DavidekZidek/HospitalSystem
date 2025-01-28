using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Abstraction;
using System.Threading.Tasks;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminDashboardController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IUserManagementService _userManagementService;

    public AdminDashboardController(IAccountService accountService, IUserManagementService userManagementService)
    {
        _accountService = accountService;
        _userManagementService = userManagementService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(); // Načte Index.cshtml
    }

    [HttpGet]
    public async Task<IActionResult> Users()
    {
        var users = await _userManagementService.GetAllUsersAsync();
        return View(users); // Načte Users.cshtml a předá seznam uživatelů
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var success = await _userManagementService.DeleteUserAsync(userId);
        TempData[success ? "SuccessMessage" : "ErrorMessage"] = success
            ? "User deleted successfully."
            : "Failed to delete user.";

        return RedirectToAction("Users"); // Po odstranění přesměruje zpět na seznam uživatelů
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _accountService.Logout(); // Volá metodu Logout v _accountService
        return RedirectToAction("Login", "Account", new { area = "Security" }); // Přesměrování na přihlašovací stránku
    }
    
    [HttpGet]
    public async Task<IActionResult> Doctors()
    {
        var doctors = await _userManagementService.GetAllDoctorsAsync();
        return View(doctors); // Předáme seznam doktorů do view
    }

    [HttpPost]
    public async Task<IActionResult> DeleteDoctor(string doctorId)
    {
        var success = await _userManagementService.DeleteUserAsync(doctorId);
        TempData[success ? "SuccessMessage" : "ErrorMessage"] = success
            ? "Doctor deleted successfully."
            : "Failed to delete doctor.";

        return RedirectToAction("Doctors");
    }

}