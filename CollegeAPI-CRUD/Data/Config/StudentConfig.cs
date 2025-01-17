using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeAPI_CRUD.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Name).HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);


            builder.HasData(new List<Student>(){
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