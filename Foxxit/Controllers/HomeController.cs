using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // public Service Service { get; private set; }

        public HomeController(/*Service service*/)
        {
            // Service = service;
        }

        public IActionResult Index()
        {
            return View("");
        }

    }
}
