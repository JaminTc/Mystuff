using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CarDealership.Models
{
    public class Car : IValidatableObject
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Make))
            {
                errors.Add(new ValidationResult("You must enter a make", new [] { "Make" }));
            }
            if (string.IsNullOrEmpty(Model))
            {
                errors.Add(new ValidationResult("You must enter a model", new[] { "Model" }));
            }
            if (string.IsNullOrEmpty(Year))
            {
                errors.Add(new ValidationResult("You must enter a year", new[] {"Year"}));
            }
            else
            {
                int numb1;
                var isYear = int.TryParse(Year, out numb1);
                if (Year.Length != 4 || !isYear)
                {
                    errors.Add(new ValidationResult("Not a valid year", new[] {"Year"}));
                }
            }
            if (string.IsNullOrEmpty(ImageUrl))
            {
                errors.Add(new ValidationResult("You must enter an Image URL", new[] { "ImageUrl" }));
            }
            if (string.IsNullOrEmpty(Title))
            {
                errors.Add(new ValidationResult("You must enter a title", new[] { "Title" }));
            }
            if (Price == 0)
            {
                errors.Add(new ValidationResult("You must enter a price", new[] { "Price" }));
            }
            if (Price < 1000)
            {
                errors.Add(new ValidationResult("The price must be higher", new[] { "Price" }));
            }
            return errors;
        }
    }
}