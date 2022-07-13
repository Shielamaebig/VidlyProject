using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Min18YearOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            //from model Min18yrOld
            //more readable than == 0 and == 1
            //Creating this Model Min18 for Validating the Age of the customer thru the year today vs input birthday
            //When the customer is not equal to 18 then he/she pic monthly quarterly or annual the result will Customer should be at least 18 year old
            //When the customer is not 18 then the membership type is pay As you go the result is success
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate id required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 year old");
        }
    }
}