using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class CourseContext:DbContext
    {
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<CourseJoin>? courseJoins { get; set; }
        public CourseContext(DbContextOptions<CourseContext> options):base(options)
        {
            
        }
        
    }
}