﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.DTOs;

namespace WebAPITest.Services
{
    public interface ICourseServices:IBasicServices
    {
        IQueryable<CourseDTO> GetCourses();
    }
}
