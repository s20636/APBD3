using Cwiczenia3.Services;
using Cwiczenia3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cwiczenia3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        { 
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id) 
        {
            Student student = _dbService.GetStudent(id);
            if (student != null) 
            {
                return Ok(student);
            }
            return NotFound("Nie znaleziono studenta");
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            IEnumerable<Student> students = _dbService.GetStudents();
            return Ok(students);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student)
        {
            bool response = _dbService.UpdateStudent(student);

            if (response)
            {
                return Ok(student);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            bool response = _dbService.AddStudent(student);
            if (response)
            {
                return Ok(student);
            }
            return BadRequest("Student istnieje w bazie");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            bool response = _dbService.DeleteStudent(id);

            if (response)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
