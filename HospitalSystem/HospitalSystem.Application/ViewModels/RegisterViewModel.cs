using System.ComponentModel.DataAnnotations;
using HospitalSystem.Domain.Validations;

namespace HospitalSystem.Application.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string? Username { get; set; }
    [FirstLetterCapitalizedCZ]
    public string? FirstName { get; set; }
    [FirstLetterCapitalizedCZ]
    public string? LastName { get; set; }
    
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Phone]
    public string? Phone { get; set; }
    
    [Required]
    [ValidPassword]
    public string? Password { get; set; }
    
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
    public string? RepeatedPassword { get; set; }
}