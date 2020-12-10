using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : Controller
    {
        // public Service Service { get; private set; }
        public FoxxitController(/*Service service*/)
        {
        }

        // [HttpGet("index")]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}