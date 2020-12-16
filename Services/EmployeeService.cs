using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Sample.API.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ApiContext _ctx;

        public EmployeeService(ApiContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _ctx.Employees.Include(e => e.Doctors);               
        }
        public Employee GetEmployeeById(int id)
        {
            return GetAll().ToList().Find(i => i.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {
            _ctx.Employees.Add(employee);
            _ctx.SaveChanges();
            if (!ExistsEmployee(employee.Id))
                throw new Exception("Employee is not created");
        }

        public bool ExistsEmployee(int id)
        {
            if (!_ctx.Employees.Any(i => i.Id == id))
            {
                return false;
            }
            return true;
        }

        public void RemoveEmployee(int id)
        {
            if (ExistsEmployee(id))
            {
                var employee = GetEmployeeById(id);

                _ctx.Employees.Remove(employee);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception("Couldn't find employee!");
            }

        }

        public void UpdateEmployee(Employee employee)
        {
            if (ExistsEmployee(employee.Id))
            {
               //var person = GetEmployeeById(employee.Id);
               // _ctx.Employees.Attach(person);
                _ctx.Employees.Update(employee);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception("Couldn't remove employee!");
            }

        }
    }
}
