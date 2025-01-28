using Microsoft.AspNetCore.Identity;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;
using HospitalSystem.Infrastructure.Identity;
using HospitalSystem.Infrastructure.Identity.Enums;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Application.Implementation;

public class AccountIdentityService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountIdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Login(LoginViewModel vm)
    {
        var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
        return result.Succeeded;
    }

    public Task Logout()
    {
        return _signInManager.SignOutAsync();
    }

    public async Task<string[]> Register(RegisterViewModel vm, params Capacitys[] roles)
    {
        // 1) Vytvoření instance uživatele
        User user = new User
        {
            UserName = vm.Username,
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            Email = vm.Email,
            PhoneNumber = vm.Phone
        };

        // 2) Vložení uživatele do databáze
        var creationResult = await _userManager.CreateAsync(user, vm.Password);

        if (creationResult.Succeeded)
        {
            // 3) Pokud nebyly zadány role, použije se výchozí role "Patient"
            if (roles == null || roles.Length == 0)
            {
                roles = new[] { Capacitys.Patient };
            }

            // 4) Přiřazení rolí uživateli
            foreach (var role in roles)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, role.ToString());
                if (!roleResult.Succeeded)
                {
                    // Pokud přiřazení role selže, přidáme chyby k hlavnímu seznamu
                    foreach (var error in roleResult.Errors)
                    {
                        creationResult.Errors.Append(error);
                    }
                }
            }
        }

        // 5) Vrácení chyb, pokud nastaly
        return creationResult.Errors.Any()
            ? creationResult.Errors.Select(e => e.Description).ToArray()
            : null;
    }

    public async Task<List<string>> GetUserRolesAsync(int userId)
    {
        // Najdi uživatele podle ID
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        // Pokud uživatel neexistuje, vrať prázdný seznam
        if (user == null)
        {
            return new List<string>();
        }

        // Získej role uživatele
        return (await _userManager.GetRolesAsync(user)).ToList();
    }

    public async Task<User> GetCurrentUserAsync(string username)
    {
        // Najdi uživatele podle uživatelského jména
        return await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }
}
