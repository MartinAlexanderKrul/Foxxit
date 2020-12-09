using System.Collections.Generic;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        // public Service Service { get; private set; }
        public FoxxitController(/*Service service*/)
        {
        }

        [HttpGet("index")]
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new MainPageViewModel();
            return View("Index", model);
        }
    }
}