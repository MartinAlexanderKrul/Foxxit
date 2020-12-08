using System;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class MainController : Controller
    {
#pragma warning disable SA1401 // Fields should be private
        protected readonly UserManager<User> userManager;
#pragma warning restore SA1401 // Fields should be private
        protected readonly SignInManager<User> signInManager;

        public MainController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        protected virtual async Task<User> GetActiveUserAsync()
        {
            var userId = userManager.GetUserId(User);
            return await userManager.FindByIdAsync(userId);
        }
    }
}