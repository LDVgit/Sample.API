using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;

namespace Sample.API.Services
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void RemoveEmployee(int id);
        void UpdateEmployee(Employee employee);
        bool ExistsEmployee(int id);
    }
}
