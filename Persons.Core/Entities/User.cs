using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Persons.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = null!;
        [Required]
        public string Lastname { get; set; } = null!;
        [Required]
        public double Salary { get; set; }
        [Required]
        [StringLength(11)]
        public string IdNumber { get; set; } = null!;
        [Required]
        public DateTime BirthDate { get; set; }
        public string? BirthCertificateId { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool teko { get; set; }
    }
}
