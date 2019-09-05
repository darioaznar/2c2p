using System;
using System.ComponentModel.DataAnnotations;

namespace _2C2P___Aznar.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    ///validation class to validate both fields not empty at the same time
    public class ValidateInquiryCriteria : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            long? CustomerID = validationContext.ObjectType.GetProperty("CustomerID") != null ? (long?)validationContext.ObjectType.GetProperty("CustomerID").GetValue(validationContext.ObjectInstance, null) : null;

            string Email = validationContext.ObjectType.GetProperty("Email") != null ? (string)validationContext.ObjectType.GetProperty("Email").GetValue(validationContext.ObjectInstance, null) : string.Empty;

            //check at least one has a value
            if (!CustomerID.HasValue && string.IsNullOrEmpty(Email))
                return new ValidationResult("No inquiry criteria");

            //todo all error messages should be in database or in resorce file
            //here for simplicty all messages are just string

            return ValidationResult.Success;
        }
    }
}
