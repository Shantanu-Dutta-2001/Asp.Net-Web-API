using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI_CRUD.Data;
using CollegeAPI_CRUD.Logger;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly CollegeDbContext _dbContext;
        public StudentController(ILogger<StudentController> logger, CollegeDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            //Ok - 200 - Success
            // _myLogger.Log("All students fetched");
            _logger.LogInformation("All students fetched");
            return Ok(_dbContext.Students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            // badRequest - 400 - BadRequest - Client Error
            if (id <= 0)
            {
                _logger.LogWarning("Bad request in GetStudentById");
                return BadRequest();
            }
            var student = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                // badRequest - 404 - NotFound - Client Error
                _logger.LogError("Student not found with given Id");
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
            var student = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();

            if (student == null)
            {
                // badRequest - 404 - NotFound - Client Error
                return NotFound($"The student with id {id} not found");
            }
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

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

            _dbContext.Students.Add(model);
            _dbContext.SaveChanges();
            //Ok - 200 - Success
            return Ok(model);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public ActionResult<Student> UpdateStudent([FromBody] Student model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = _dbContext.Students.Where(s => s.Id == model.Id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Name = model.Name;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;
            _dbContext.SaveChanges();

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
            var existingStudent = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            var student = new Student
            {
                Id = existingStudent.Id,
                Name = existingStudent.Name,
                Email = existingStudent.Email,
                Address = existingStudent.Address
            };
            patchDocument.ApplyTo(student, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Address = student.Address;
            _dbContext.SaveChanges();

            return Ok(existingStudent);
        }
    }
}