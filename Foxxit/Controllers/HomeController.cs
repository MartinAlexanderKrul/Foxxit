using System.Collections.Generic;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
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
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new MainPageViewModel();
            return View("Index", model);
        }
    }
}