using HospitalSystem.Application.ViewModels;
using HospitalSystem.Infrastructure.Identity.Enums;

namespace HospitalSystem.Application.Abstraction;

public interface IAccountService
{
    Task<bool> Login(LoginViewModel vm);
    
    Task Logout();
    
    Task<string[]> Register(RegisterViewModel vm, params Capacitys[] roles);
}