using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumMeetingSheduler.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public User()
        {
            Projects = new List<Project>();
        }
    }
}
