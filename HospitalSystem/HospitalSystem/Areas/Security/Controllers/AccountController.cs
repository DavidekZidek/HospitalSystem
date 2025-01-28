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

        // GET: Security/Account/Register
        public IActionResult Register()
        {
            // Pokud je uživatel přihlášen, přesměrujeme jej do Dashboardu
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "User" });
            }

            return View();
        }

        // POST: Security/Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                string[] errors = await _accountService.Register(registerVM);
                if (errors == null)
                {
                    // Přihlášení uživatele po úspěšné registraci
                    LoginViewModel loginVM = new LoginViewModel
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };
                    bool isLogged = await _accountService.Login(loginVM);

                    if (isLogged)
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }
                }
                else
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            return View(registerVM);
        }

        // GET: Security/Account/Login
        public IActionResult Login()
        {
            // Pokud je uživatel přihlášen, přesměrujeme jej do Dashboardu
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "User" });
            }

            return View();
        }

        // POST: Security/Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                bool isLogged = await _accountService.Login(loginVM);

                if (isLogged)
                {
                    // Přesměrování do oblasti User po úspěšném přihlášení
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            loginVM.LoginFailed = true;
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

        // Automatické odhlášení při spuštění aplikace
        public async Task<IActionResult> AutoLogout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _accountService.Logout();
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
