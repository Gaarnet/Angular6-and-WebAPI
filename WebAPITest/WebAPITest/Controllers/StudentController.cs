using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.DTOs;
using WebAPITest.Models;
using WebAPITest.Services;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }


        // GET: api/Student
        [HttpGet("students/{page}", Name ="students")]
        [DisableCors]
        public StudentDataSource GetStudents(int page)
        {
           return _studentServices.GetStudents(page);
        }

        //GET: api/Student/5
        [HttpGet("{id}", Name = "Gets")]
        public StudentDTO Gets(int id)
        {
            return _studentServices.GetStudent(id);
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] StudentDTO student)
        {
            _studentServices.AddStudent(student);

        }

        // PUT: api/Student/5
        [HttpPut]
        public void Put( [FromBody] StudentDTO student)
        {
            _studentServices.UpdateStudent(student);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            _studentServices.Delete(Id);
        }
    }
}
