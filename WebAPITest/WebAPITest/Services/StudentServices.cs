using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Context;
using WebAPITest.DTOs;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentContext _dbContext;

        public StudentServices(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddStudent(StudentDTO student)
        {
            if (student.Id == 0)
            {
                var newStudent = new Student();
                newStudent.Id = student.Id;
                newStudent.Name = student.Name;
                newStudent.Age = student.Age.HasValue ? student.Age.Value : default(int);
         
                _dbContext.Students.Add(newStudent);
                _dbContext.SaveChanges();

                int id = newStudent.Id;
                _dbContext.StudentCourse.AddRange(student.Courses.Where(c=>c.IsChecked).Select(c => new StudentCourse()
                {
                    CourseId = c.Id,
                    StudentId=id
                }));
                _dbContext.SaveChanges();

            }
            else
            {

                var dbCourses = _dbContext.StudentCourse.Where(s => s.StudentId == student.Id).ToList();
                var cRemove = (from db in dbCourses
                              join st in student.Courses on db.CourseId equals st.Id 
                              where st.IsChecked == false
                              select db);

                var cAdd = from st in student.Courses
                           join db in dbCourses on st.Id equals db.CourseId into tmp
                           from tc in tmp.DefaultIfEmpty()
                           where st.IsChecked == true && tc == null
                           select new StudentCourse()
                           {
                               CourseId = st.Id,
                               StudentId = student.Id
                           };

                _dbContext.StudentCourse.AddRange(cAdd);
                _dbContext.StudentCourse.RemoveRange(cRemove);

                Student student2Add = new Student();
                student2Add.Id = student.Id;
                student2Add.Name = student.Name;
                student2Add.Age = student.Age.HasValue ? student.Age.Value : default(int);
                _dbContext.Students.Update(student2Add);
                _dbContext.SaveChanges();
            }
        }


            public void Delete(int id)
        {
           var deleteStudent= _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Students.Remove(deleteStudent);
            _dbContext.SaveChanges();
        }

        public StudentDTO GetStudent(int id )
        {
            var dbStudent = new StudentDTO();

            if (id != -1)
            {
                dbStudent = (from s in _dbContext.Students
                             join sc in _dbContext.StudentCourse on s.Id equals sc.StudentId into stc
                             from dsc in stc.DefaultIfEmpty()


                             select new StudentDTO()
                             {
                                 Id = s.Id,
                                 Name = s.Name,
                                 Age = s.Age,

                                 Courses = (from mc in stc
                                           join c in _dbContext.Courses on mc.CourseId equals c.Id
                                           select new CourseDTO()
                                           {
                                               Name = c.CourseName,
                                               Id = c.Id,
                                               IsChecked = true
                                           }).ToList()
                                 }).FirstOrDefault(x => x.Id == id);


                var studentCoursesIds = dbStudent.Courses.Select(s => s.Id);
                var notSelectedCourses= _dbContext.Courses.Where(w=> !studentCoursesIds.Contains(w.Id)).Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.CourseName,
                    IsChecked = false
                }).AsEnumerable();

                dbStudent.Courses.AddRange(notSelectedCourses);
            }
            else
            {
                dbStudent.Courses = _dbContext.Courses.Select(s => new CourseDTO
                {
                    Id = s.Id,
                    Name = s.CourseName,
                    IsChecked=false
                }).ToList();
            }
            return dbStudent;
        }

        public StudentDataSource GetStudents(int pc)
        {
            StudentDataSource std = new StudentDataSource();
            std.Pages = new List<int>();
            for (int i = 1; i <= _dbContext.Students.Count()/10; i++)
            {
                std.Pages.Add(i);
            }
            

            var studentsFromDb = (from s in _dbContext.Students
                                  join sc in _dbContext.StudentCourse on s.Id equals sc.StudentId into stc
                                  select new StudentDTO()
                                  {
                                      Id = s.Id,
                                      Name = s.Name,
                                      Age = s.Age,
                                      Courses = (from mc in stc
                                                 join c in _dbContext.Courses on mc.CourseId equals c.Id
                                                 select new CourseDTO()
                                                 {
                                                     Name = c.CourseName,
                                                     Id = c.Id,
                                                     IsChecked = true

                                                 }).ToList()
                                  }).Skip(pc*10).Take(10);

            std.Students = studentsFromDb;

            return std;
        }

        public IQueryable<StudentDTO> GetStudents(int pc, string cc)
        {
            var studentsFromDb = (from s in _dbContext.Students
                                  join sc in _dbContext.StudentCourse on s.Id equals sc.StudentId into stc
                                  select new StudentDTO()
                                  {
                                      Id = s.Id,
                                      Name = s.Name,
                                      Age = s.Age,
                                     pageCount=_dbContext.Students.Count()/10,
                                     Courses = (from mc in stc
                                                join c in _dbContext.Courses on mc.CourseId equals c.Id
                                                select new CourseDTO()
                                                {
                                                    Name = c.CourseName,
                                                    Id = c.Id,
                                                    IsChecked = true
                                                  
                                               }).ToList()
                                 }).Skip(pc*10).Take(10);
                                 
                
               
            return studentsFromDb;
        }

        public void UpdateStudent(StudentDTO student)
        {
            _dbContext.Students.Update(new Student());
            _dbContext.SaveChanges();
        }
    }
}
