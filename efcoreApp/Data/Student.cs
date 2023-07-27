using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentLastName { get; set; }
        public string adsoyad { get{
            return this.StudentName+" " + this.StudentLastName;
        } }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<CourseJoin> joinlist { get; set; }    
    }
}