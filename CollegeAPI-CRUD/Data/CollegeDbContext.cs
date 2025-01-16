using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI_CRUD.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }
        DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new List<Student>(){
                new Student {
                    Id = 1,
                    Name = "Aarav",
                    Address = "Gujarat,India",
                    Email = "Aarav@gmail.in",
                    DOB = new DateTime(2001,01,22)
                },
                new Student {
                    Id = 2,
                    Name = "Bishops",
                    Address = "Melbourne,Australia",
                    Email = "Bishops@gmail.com",
                    DOB = new DateTime(2002,05,15)
                },
                 new Student {
                    Id = 3,
                    Name = "Chirag",
                    Address = "Maharashtra,India",
                    Email = "Chirag@gmail.in",
                    DOB = new DateTime(2001,11,18)
                }
            });
        }
    }
}