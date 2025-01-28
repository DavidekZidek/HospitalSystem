using Microsoft.AspNetCore.Identity;
using HospitalSystem.Application.Abstraction;
using HospitalSystem.Application.ViewModels;
using HospitalSystem.Infrastructure.Identity;
using HospitalSystem.Infrastructure.Identity.Enums;

namespace HospitalSystem.Application.Implementation;

public class AccountIdentityService : IAccountService
{
    UserManager<User> userManager;
    SignInManager<User> signInManager;
    
    public AccountIdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    
    public async Task<bool> Login(LoginViewModel vm)
    {
        var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
        return result.Succeeded;
    }
    
    public Task Logout()
    {
        return signInManager.SignOutAsync();
    }
    
    public async Task<string[]> Register(RegisterViewModel vm, params Capacitys[] roles)
    {
        // 1) Vytvoříme entitu uživatele
        User user = new User
        {
            UserName   = vm.Username,
            FirstName  = vm.FirstName,
            LastName   = vm.LastName,
            Email      = vm.Email,
            PhoneNumber= vm.Phone
        };
        
        // 2) Vytvoření v DB
        var result = await userManager.CreateAsync(user, vm.Password);

        if (result.Succeeded)
        {
            // --- Přidání výchozí role "Patient", pokud se nepošle nic ---
            if (roles == null || roles.Length == 0)
            {
                roles = new[] { Capacitys.Patient };
            }

            // 3) Přiřazení rolí
            foreach (var role in roles)
            {
                var resultRole = await userManager.AddToRoleAsync(user, role.ToString());
                // Pro případ, že AddToRoleAsync selže:
                if (!resultRole.Succeeded)
                {
                    // Sloučení chyb do result.Errors
                    foreach (var err in resultRole.Errors)
                    {
                        result.Errors.Append(err);
                    }
                }
            }
        }
        
        // 4) Pokud se vyskytly jakékoli chyby, přepíšeme je do string[] errors
        string[] errors = null;
        if (result.Errors != null && result.Errors.Any())
        {
            errors = result.Errors.Select(e => e.Description).ToArray();
        }

        return errors;
    }
}
