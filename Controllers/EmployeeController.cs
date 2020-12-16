using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.API.Services;
using Sample.API.Models;

namespace Medicine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _src;
        public EmployeeController(IEmployee src)
        {
            _src = src;
        }

        //http://localhost:5000/api/Employee/GetEmployees
        [HttpGet("GetEmployees")]
        public ActionResult Get()
        {
            return Ok(_src.GetAll());
        }

        [HttpGet("GetEmployeeById/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_src.GetEmployeeById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            _src.CreateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("RemoveEmployee/{id}")]
        public ActionResult RemoveEmployee(int id)
        {
            _src.RemoveEmployee(id);
            return Ok();
        }

        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _src.UpdateEmployee(employee);
            return Ok(employee);
        }
    }
}
