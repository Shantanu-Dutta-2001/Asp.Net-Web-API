using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI_CRUD.Logger;
using CollegeAPI_CRUD.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMyLogger _myLogger;

        public StudentController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
        }
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            //Ok - 200 - Success
            _myLogger.Log("All students fetched");
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
                Age = model.Age,
                Address = model.Address,
                Email = model.Email
            };
            StudentRepository.Students.Add(stu);
            model.StudentId = stu.StudentId;
            //Ok - 200 - Success
            return Ok(model);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public ActionResult<Student> UpdateStudent([FromBody] Student model)
        {
            if (model == null || model.StudentId <= 0)
            {
                return BadRequest();
            }
            var existingStudent = StudentRepository.Students.Where(s => s.StudentId == model.StudentId).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.StudentName = model.StudentName;
            existingStudent.Age = model.Age;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;
            // existingStudent.AddmissionDate = model.AddmissionDate;

            return Ok(existingStudent);
        }
        [HttpPatch]
        [Route("{id:int}/UpdateStudentByPatch")]

        public ActionResult<Student> UpdateStudentByPatch(int id, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = StudentRepository.Students.Where(s => s.StudentId == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            var student = new Student
            {
                StudentId = existingStudent.StudentId,
                StudentName = existingStudent.StudentName,
                Age = existingStudent.Age,
                Email = existingStudent.Email,
                Address = existingStudent.Address
            };
            patchDocument.ApplyTo(student, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingStudent.StudentName = student.StudentName;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            existingStudent.Address = student.Address;

            return Ok(existingStudent);
        }
    }
}