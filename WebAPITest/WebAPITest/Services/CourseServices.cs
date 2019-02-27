using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Context;
using WebAPITest.DTOs;

namespace WebAPITest.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly StudentContext _dbContext;

        public CourseServices(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CourseDTO> GetCourses()
        {
            var dbCourses = from c in _dbContext.Courses
                                 
                                 select new CourseDTO()
                                 {
                                    Id=c.Id,
                                    Name=c.CourseName
                                   
                                 };

            return dbCourses;
        }
    }
}
