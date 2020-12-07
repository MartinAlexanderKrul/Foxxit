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

        //[HttpGet("subreddit")]
        //public async IActionResult Subreddit()
        //{

        //}

    }
}