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
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialty _src;
        public SpecialtyController(ISpecialty src)
        {
            _src = src;
        }

        [HttpGet("GetSpecialties")]
        public ActionResult Get()
        {
            return Ok(_src.GetAll());
        }

        [HttpGet("GetSpecialtyById")]
        public ActionResult Get(int id)
        {
            return Ok(_src.GetSpecialtyById(id));
        }

        [HttpPost("NewSpecial")]
        public ActionResult Post ([FromBody] Specialty sp)
        {
            _src.AddSpecialty(sp);
            return Ok(sp);
        }

        [HttpPut("UpdateSpecialty")]
        public ActionResult Put([FromBody] Specialty sp)
        {
            _src.UpdateSpecialty(sp);
            return Ok();
        }

        [HttpDelete("RemoveSpecialty")]
        public ActionResult Delete(int id)
        {
            _src.RemoveSpecialty(id);
            return Ok();
        }

    }
}