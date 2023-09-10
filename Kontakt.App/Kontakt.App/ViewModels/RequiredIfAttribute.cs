using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class RequiredIfAttribute : ValidationAttribute
{
    private string PropertyName { get; }
    private object DesiredValue { get; }

    public RequiredIfAttribute(string propertyName, object desiredValue)
    {
        PropertyName = propertyName;
        DesiredValue = desiredValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance;
        var propertyInfo = instance.GetType().GetProperty(PropertyName);

        if (propertyInfo != null)
        {
            var propertyValue = propertyInfo.GetValue(instance);

            if (propertyValue.Equals(DesiredValue) && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}
