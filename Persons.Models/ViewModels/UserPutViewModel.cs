using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Models.ViewModels
{
    public class UserPutViewModel
    {
        public string IdNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
