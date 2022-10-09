using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Models.ViewModels
{
    public class UserCreateViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Salary { get; set; }
        public string? BirthCertificateId { get; set; }
        public string? Address { get; set; }
    }
}
