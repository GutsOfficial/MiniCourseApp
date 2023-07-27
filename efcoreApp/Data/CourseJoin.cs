using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class CourseJoin
    {
        [Key]
        public int JoinId { get; set; }
        public int StudentId { get; set; }
        public Student ogrenci { get; set; }=null!;
        public int CourseId { get; set; }
        public Course kurs { get; set; }=null!;
        public DateTime CourseDate { get; set; }
        

    }
}