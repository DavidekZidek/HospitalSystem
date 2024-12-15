using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Areas.Security.Controllers;

[Area("Security")]
public class AccountController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
}