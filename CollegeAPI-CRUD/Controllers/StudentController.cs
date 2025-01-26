using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CollegeAPI_CRUD.Data;
using CollegeAPI_CRUD.Logger;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly CollegeDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentController(ILogger<StudentController> logger, CollegeDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            //Ok - 200 - Success
            // _myLogger.Log("All students fetched");

            // For auto mapper 
            var students = _dbContext.Students;
            var studentDtoData = _mapper.Map<List<StudentDTO>>(students);


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
            var existingStudent = _dbContext.Students.AsNoTracking().Where(s => s.Id == model.Id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound();
            }
            var neWRecordToUpdate = new Student()
            {
                Id = existingStudent.Id,
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                DOB = model.DOB
            };
            _dbContext.Students.Update(neWRecordToUpdate);
            _dbContext.SaveChanges();
            // existingStudent.Name = model.Name;
            // existingStudent.Email = model.Email;
            // existingStudent.Address = model.Address;

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