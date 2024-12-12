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
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            //Ok - 200 - Success
            return Ok(StudentRepository.Students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            // badRequest - 400 - BadRequest - Client Error
            if (id <= 0)
            {
                return BadRequest();
            }
            var student = StudentRepository.Students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student == null)
            {
                // badRequest - 404 - NotFound - Client Error
                return NotFound($"The student with id {id} not found");
            }
            //Ok - 200 - Success
            return Ok(student);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<bool> DeleteStudentById(int id)
        {
            // badRequest - 400 - BadRequest - Client Error
            if (id <= 0)
            {
                return BadRequest();
            }
            var student = StudentRepository.Students.Where(s => s.StudentId == id).FirstOrDefault();

            if (student == null)
            {
                // badRequest - 404 - NotFound - Client Error
                return NotFound($"The student with id {id} not found");
            }
            StudentRepository.Students.Remove(student);

            //Ok - 200 - Success
            return Ok(true);
        }
        [HttpPost]
        [Route("AddStudent")]
        public ActionResult<Student> AddStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }
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
            //Ok - 200 - Success
            return Ok(model);
        }
    }
}