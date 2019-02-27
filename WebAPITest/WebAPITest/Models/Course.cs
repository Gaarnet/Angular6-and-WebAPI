using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
