using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Tutdocs.Application.CustomValidators
{
    public sealed class PasswordValidator: ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field must be at least 6 characters long and contain at least one letter, and one digit.";
        private Regex hasNumber = new Regex(@"[0-9]+");
        private Regex hasLetter = new Regex(@"[a-zA-Z]+");
        private Regex hasMinimum6Chars = new Regex(@".{6,}");
        public PasswordValidator() : base(DefaultErrorMessage) { }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            string password = value as string;
            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            var isValidated = hasNumber.IsMatch(password) && hasLetter.IsMatch(password) && hasMinimum6Chars.IsMatch(password);

            if (isValidated)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}
