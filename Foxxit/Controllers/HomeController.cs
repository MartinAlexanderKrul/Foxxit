using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}