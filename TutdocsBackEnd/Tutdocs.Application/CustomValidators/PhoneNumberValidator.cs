using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Tutdocs.Application.CustomValidators
{
    public sealed class PhoneNumberValidator : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid phone number.";

        public PhoneNumberValidator() : base(DefaultErrorMessage) { }
        
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            string phoneNumber = value as string;
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            // Simple phone regex pattern for validation (allows numbers, spaces, dashes, parentheses, and plus signs)
            var phoneRegex = new Regex(@"^(?:\+88|88)?(01[3-9]\d{8})$", RegexOptions.Compiled);

            if (phoneRegex.IsMatch(phoneNumber))
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
