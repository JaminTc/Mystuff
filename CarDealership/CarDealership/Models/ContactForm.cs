using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class ContactForm : IValidatableObject
    {
        // Your task is to:
        //
        // Make all fields required
        // Ensure the Email field contains an '@' symbol
        // Ensure PhoneNumber is in the format: 1-XXX-XXX-XXXX
        // If the Income is less than 10000 and the PurchaseTimeFrameInMonts is greater than 12,
        // generate a model level area that says 'We don't want your business!'

        public string Name { get; set; }
        public int PurchaseTimeFrameInMonths { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
        public decimal? Income { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationResult("Name field is requried", new string[] { "Name" }));
            }
            if (string.IsNullOrEmpty(PhoneNumber)) PhoneNumber = "";
            PhoneNumber = PhoneNumber.Replace("-", "");
            long phoneNumberAsInt;
            var isNumber = long.TryParse(PhoneNumber, out phoneNumberAsInt);
            if (isNumber == false || (PhoneNumber.Length != 11) && (PhoneNumber.Length != 10) && (
                PhoneNumber.Length != 7))
            {
                errors.Add(new ValidationResult("Not a valid Phone Number", new string[] { "PhoneNumber" }));
            }
            if (PhoneNumber.Length == 11 && PhoneNumber.Substring(0, 1) != "1")
            {
                errors.Add(new ValidationResult("Not a valid Phone Number", new string[] { "PhoneNumber" }));
            }
            if (PurchaseTimeFrameInMonths > 12 && Income < 10000)
            {
                errors.Add(new ValidationResult(""));
            }
            if (Income == null)
            {
                errors.Add(new ValidationResult("Income must not be empty", new string[] { "Income" }));
            }

            return errors;
        }
    }
}