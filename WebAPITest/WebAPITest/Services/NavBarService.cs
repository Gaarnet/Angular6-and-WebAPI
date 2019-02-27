using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Context;
using WebAPITest.DTOs;

namespace WebAPITest.Services
{
    public class NavBarService : INavBarService
    {
        private readonly StudentContext _dbContext;

        public NavBarService(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<NavBarLinksDTO> GetLinks()
        {
            var Links = _dbContext.NBL.Select(l=> new NavBarLinksDTO {
                Id=l.Id,
                LinkName=l.LinkName,
                LinkPath=l.LinkPath,
                Icons=l.Icons
            }).ToList();
            return Links;
        }
    }
}
