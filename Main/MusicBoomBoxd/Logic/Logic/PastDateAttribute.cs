using System;
using System.ComponentModel.DataAnnotations;

public class PastDateAttribute : ValidationAttribute
{
    public ValidationResult ValidateDate(DateTime date)
    {
        if (date.Date >= DateTime.Today)
        {
            return new ValidationResult("Birthday cannot be today or a future date");
        }
        return ValidationResult.Success;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Birthday is required");
        }

        DateTime dateValue;
        if (DateTime.TryParse(value.ToString(), out dateValue))
        {
            return ValidateDate(dateValue);
        }
        else
        {
            return new ValidationResult("Invalid date format");
        }
    }
}
