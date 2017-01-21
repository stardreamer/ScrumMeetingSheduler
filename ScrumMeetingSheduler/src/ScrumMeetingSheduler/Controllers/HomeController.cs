using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumMeetingSheduler.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var fileName = "index.html";
            var contentType = "text/html";

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            string fileContents = System.IO.File.ReadAllText(filePath);

            return Content(fileContents, contentType);
        }
    }
}
