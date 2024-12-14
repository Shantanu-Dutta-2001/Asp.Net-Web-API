using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAPI_CRUD.Model
{
    public class StudentRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>() {
             new Student {
                StudentId = 1,
                StudentName = "Aakash Patel",
                Age = 15,
                Email = "aakash@gmail.in",
                Address= "Surat, Gujarat",
                },
                new Student {
                StudentId = 2,
                StudentName = "Bipin Patel",
                Age = 18,
                Email = "bipin@gmail.in",
                Address= "Vadodara, Gujarat"
                }
        };
    }
}