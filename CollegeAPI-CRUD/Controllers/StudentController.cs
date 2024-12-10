using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI_CRUD.Model;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All")]
        public IEnumerable<Student> GetStudents()
        {
            return StudentRepository.Students;
        }

        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return StudentRepository.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }
        [HttpDelete("{id:int}")]
        public bool DeleteStudentById(int id)
        {
            var student = StudentRepository.Students.Where(s => s.StudentId == id).FirstOrDefault();

            StudentRepository.Students.Remove(student);

            return true;
        }
        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student model)
        {
            int newId = StudentRepository.Students.LastOrDefault().StudentId + 1;

            Student stu = new Student
            {
                StudentId = newId,
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email
            };
            StudentRepository.Students.Add(stu);
            model.StudentId = stu.StudentId;
            return Ok(model);
        }
    }
}