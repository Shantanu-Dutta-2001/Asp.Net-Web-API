using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAPI_CRUD.Data
{
    public class Department
    {
        public int Id { get; set; }
        public required string DepartmentName { get; set; }
        public required string Description { get; set; }
        public required string Code { get; set; }
        public int EstablishedYear { get; set; }
        public int TotalFaculty { get; set; }
        public int TotalStudents { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}