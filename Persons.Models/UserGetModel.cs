using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models
{
    public class UserGetModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public string? BirthCertificateId { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public double AverageSalary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
