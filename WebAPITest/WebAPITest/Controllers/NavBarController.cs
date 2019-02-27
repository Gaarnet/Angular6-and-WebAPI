using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.DTOs;
using WebAPITest.Services;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavBarController : ControllerBase
    {
        INavBarService _navBarService;

        public NavBarController(INavBarService NavBarService)
        {
            _navBarService = NavBarService;
        }

        // GET: api/NavBar
        [HttpGet]
        public List<NavBarLinksDTO> Get()
        {
            return _navBarService.GetLinks();
        }

        // GET: api/NavBar/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NavBar
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/NavBar/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
