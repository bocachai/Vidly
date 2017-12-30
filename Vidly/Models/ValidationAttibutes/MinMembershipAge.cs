using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MinMembershipAge: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unkown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of birth is required");

            DateTime now = DateTime.Today;
            int age = now.Year - customer.DateOfBirth.GetValueOrDefault().Year;
            if (customer.DateOfBirth.GetValueOrDefault() > now.AddYears(-age))
                age--;

            return (age < 18)
                ? new ValidationResult("Customer must be at least 18 years of age")
                : ValidationResult.Success;
        }
    }
}