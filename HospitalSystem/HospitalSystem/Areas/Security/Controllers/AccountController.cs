using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;

namespace HospitalSystem.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Security/Account/Login
        public IActionResult Login()
        {
            // Pokud je uživatel přihlášen, přesměrujeme jej na odpovídající dashboard
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
                }
                return RedirectToAction("Index", "Dashboard", new { area = "User" });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await _accountService.Login(loginVM);

                if (isLogged)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return View(loginVM);
        }


        // POST: Security/Account/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // Odhlášení uživatele
            await _accountService.Logout();

            // Přesměrování na přihlašovací stránku
            return RedirectToAction(nameof(Login));
        }
    }
}
