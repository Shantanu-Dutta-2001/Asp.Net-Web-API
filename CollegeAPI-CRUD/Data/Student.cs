using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAPI_CRUD.Data
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public DateTime DOB { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

    }
}