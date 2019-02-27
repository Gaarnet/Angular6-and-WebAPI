using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.DTOs
{
    public class StudentDataSource
    {
        public List<int> Pages { get; set; }
        public IQueryable<StudentDTO> Students { get; set; }
    }
}
