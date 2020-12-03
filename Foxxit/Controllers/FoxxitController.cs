using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        // public Service Service { get; private set; }

        public FoxxitController(/*Service service*/)
        {
            // Service = service;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
