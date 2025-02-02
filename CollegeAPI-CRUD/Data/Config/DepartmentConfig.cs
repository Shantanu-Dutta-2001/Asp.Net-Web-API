using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeAPI_CRUD.Data.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(n => n.DepartmentName).IsRequired();
            builder.Property(n => n.DepartmentName).HasMaxLength(250);
            builder.Property(n => n.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Code).IsRequired().HasMaxLength(250);
            builder.Property(n => n.EstablishedYear).IsRequired();
            builder.Property(n => n.TotalStudents).IsRequired().HasDefaultValue(0);
            builder.Property(n => n.TotalFaculty).IsRequired().HasDefaultValue(0);


            builder.HasData(new List<Department>(){
                new Department {
                    Id = 1,
                    DepartmentName = "Electronic & Communication",
                    Description = "Deals with electronic devices, circuits, and communication systems",
                    Code = "ECE",
                    EstablishedYear = 1995,
                    TotalFaculty = 25,
                    TotalStudents = 450
                },

                new Department {
                    Id = 2,
                    DepartmentName = "Computer Science & Engineering",
                    Description = "Focuses on computing, programming, and software development",
                    Code = "CSE",
                    EstablishedYear = 2000,
                    TotalFaculty = 30,
                    TotalStudents = 600
                },

                new Department {
                    Id = 3,
                    DepartmentName = "Mechanical Engineering",
                    Description = "Covers machine design, manufacturing, and automation",
                    Code = "ME",
                    EstablishedYear = 1985,
                    TotalFaculty = 20,
                    TotalStudents = 400
                },

                new Department {
                    Id = 4,
                    DepartmentName = "Civil Engineering",
                    Description = "Involves construction, design, and infrastructure development",
                    Code = "CE",
                    EstablishedYear = 1980,
                    TotalFaculty = 22,
                    TotalStudents = 350
                },

                new Department {
                    Id = 5,
                    DepartmentName = "Electrical Engineering",
                    Description = "Deals with electrical systems, power generation, and electronics",
                    Code = "EE",
                    EstablishedYear = 1990,
                    TotalFaculty = 24,
                    TotalStudents = 420
                }
            });
        }
    }
}