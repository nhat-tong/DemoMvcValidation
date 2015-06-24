using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NewValidationMvc.Validation
{
    /// <summary>
    /// Permet la validation de date par comparaison avec une autre date du formulaire
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class DateValidationAttribute : ValidationAttribute
    {
        private ValidationType _validationType;
        private DateTime? _fromDate;
        private DateTime _toDate;
        private string _defaultErrorMessage;
        private string _propertyNameToCompare;

        public DateValidationAttribute(ValidationType validationType, string message, string compareWith = "", string fromDate = "")
        {
            _validationType = validationType;
            switch (validationType)
            {
                case ValidationType.Compare:
                    {
                        _propertyNameToCompare = compareWith;
                        _defaultErrorMessage = message;
                        break;
                    }
                case ValidationType.RangeValidation:
                    {
                        _fromDate = new DateTime(2000, 1, 1);
                        _toDate = DateTime.Today;
                        _defaultErrorMessage = message;
                        break;
                    }

            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (_validationType)
            {
                case ValidationType.Compare:
                    {
                        var baseProperyInfo = validationContext.ObjectType.GetProperty(_propertyNameToCompare);
                        var startDate = (DateTime)baseProperyInfo.GetValue(validationContext.ObjectInstance, null);

                        if (value != null)
                        {

                            DateTime thisDate = (DateTime)value;
                            if (thisDate <= startDate)
                            {
                                return new ValidationResult(string.Format(_defaultErrorMessage, validationContext.DisplayName));
                            }
                        }
                        break;
                    }
                case ValidationType.RangeValidation:
                    {
                        //Range Validation Logic Here
                        throw new NotImplementedException();
                    }

            }
            return ValidationResult.Success;
        }
    }

    public enum ValidationType
    {
        RangeValidation,
        Compare
    }
}