using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI_CRUD.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI_CRUD.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
        }
    }
}