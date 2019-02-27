using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.DTOs;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public interface IStudentServices:IBasicServices
    {
        IQueryable<StudentDTO>GetStudents(int pc, string cc);
        StudentDataSource GetStudents(int pc);
        StudentDTO GetStudent(int id);
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
    }
}
