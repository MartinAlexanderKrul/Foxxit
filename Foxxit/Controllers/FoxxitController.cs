using System.Collections.Generic;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class FoxxitController : MainController
    {
        public FoxxitController(UserManager<User> userManager, SignInManager<User> signInManager)
            : base(userManager, signInManager)
        {
        }

        [HttpGet("index")]
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new MainPageViewModel() { ActualUser = new User() { UserName = "Nicolburg", Id = 1 } };
            return View("Index", model);
        }
    }
}