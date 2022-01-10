using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeApp.Models {
    public class Min18YearsIfAMember : ValidationAttribute{

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var voter = (Voter)validationContext.ObjectInstance;

            if (voter.MembershipTypeId == MembershipType.Unknown || 
                voter.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (voter.BirthDate is null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - voter.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Voter should be at least 18 years old.");
        }
    }
}