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

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("doubling")]
        public ActionResult Doubling(int? input)
        {
            if (input != null)
            {
                var result = Json(new { received = input, result = input * 2 });
                
                return result;
            }
            else
            {
                var result = Json(new { error = "Please provide an input!" });
                
                return result;
            }
        }

    }
}
