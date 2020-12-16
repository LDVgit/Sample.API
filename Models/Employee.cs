using System;
using System.Collections.Generic;

namespace Sample.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DayOfBirth { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

    }
}
