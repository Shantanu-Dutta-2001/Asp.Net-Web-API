using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI_CRUD.Data
{
    public class CollegeDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }
    }
}