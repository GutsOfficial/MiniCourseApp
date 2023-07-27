using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public ICollection<CourseJoin> joinlist { get; set; }    

    }
}