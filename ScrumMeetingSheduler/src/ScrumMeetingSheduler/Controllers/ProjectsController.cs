using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrumMeetingSheduler.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumMeetingSheduler.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        List<Project> _projects = new List<Project>()
        {
            new Project{Id = 1, Name = "302"},
            new Project{Id = 2, Name = "374"},
            new Project{Id = 3, Name = "GeoOpt"},

        };


        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projects;
        }

        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]ICollection<Project> projects)
        {
            _projects.AddRange(projects);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Project project)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
