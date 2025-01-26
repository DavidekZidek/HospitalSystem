using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HospitalSystem.Domain.Validations
{
    
    /// <summary>
    /// <para>Validates the password.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidPasswordAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _minLength;
        private static readonly Regex _specialCharRegex = new Regex(@"[^a-zA-Z0-9]", RegexOptions.Compiled);

        public ValidPasswordAttribute(int minLength = 8)
        {
            _minLength = minLength;
        }

        // The password must be at least _minLength characters long. 
        // The password must contain at least one uppercase letter.
        // The password must contain at least one lowercase letter.
        // The password must contain at least one number.
        // The password must not contain special symbols.
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is string text)
            {
                if (text == string.Empty)
                    return ValidationResult.Success;

                if (text.Length < _minLength)
                {
                    return new ValidationResult($"The length of the password must be at least {_minLength}.");
                }
                else if (!text.Any(char.IsUpper))
                {
                    return new ValidationResult("The password must contain at least one uppercase letter.");
                }
                else if (!text.Any(char.IsLower))
                {
                    return new ValidationResult("The password must contain at least one lowercase letter.");
                }
                else if (!text.Any(char.IsDigit))
                {
                    return new ValidationResult("The password must contain at least one number.");
                }
                else if (_specialCharRegex.IsMatch(text))
                {
                    return new ValidationResult("The password must not contain special symbols.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult($"The {nameof(ValidPasswordAttribute)} attribute can only be applied to string properties.");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-validpassword", $"The length of the password must be at least {_minLength} and must contain at least one uppercase letter, one lowercase letter, one number and cannot contain any special symbols.");
        }
    }


}
