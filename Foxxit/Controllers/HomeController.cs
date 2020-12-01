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
        public PartialViewResult _HeaderViewPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ContentViewPartial()
        {
            return PartialView();
        }



    }
}
