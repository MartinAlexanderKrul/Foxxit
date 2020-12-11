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
        public UserManager<User> UserManager { get; protected set; }
        public SignInManager<User> SignInManager { get; protected set; }

        public MainController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        protected virtual async Task<User> GetActiveUserAsync()
        {
            var userId = UserManager.GetUserId(User);
            return await UserManager.FindByIdAsync(userId);
        }
    }
}