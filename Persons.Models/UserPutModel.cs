using System.ComponentModel.DataAnnotations;
using Persons.Core.Utility;

namespace Persons.Models
{
    public class UserPutModel : IValidatableObject
    {
        [Required]
        public string Firstname { get; set; } = null!;
        [Required]
        public string Lastname { get; set; } = null!;
        [Required]
        public double Salary { get; set; }
        [Required]
        public string IdNumber { get; set; } = null!;
        [Required]
        public DateTime BirthDate { get; set; }
        public string? BirthCertificateId { get; set; }
        public string? Address { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (AgeCalculator.CalculateAge(BirthDate) < 18 && string.IsNullOrEmpty(BirthCertificateId))
            {
                result.Add(new ValidationResult("Birth certificate is required for users under age 18"));
            }

            if (DateTime.Compare(BirthDate, DateTime.Now) > 0)
            {
                result.Add(new ValidationResult("Invalid birth date"));
            }

            if (IdNumber.Length != 11)
            {
                result.Add(new ValidationResult("Id number must have 11 digit"));
            }
            

            return result;
        }
    }
}
