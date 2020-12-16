using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;

namespace Sample.API.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public Employee Employeer { get; set; }
        public Specialty Physician { get; set; }
        public string Qualification { get; set; }

    }
}
