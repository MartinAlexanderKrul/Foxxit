using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserService userService;
        private readonly SignInManager<UserModelxxx> signInManager;
        private readonly UserManager<UserModelxxx> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserService userService, SignInManager<UserModelxxx> signInManager, UserManager<UserModelxxx> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            if (userManager.FindByNameAsync(model.UserName) == null)
            {
                var user = new UserModelxxx
                {
                    UserName = model.UserName,
                    DisplayName = model.DisplayName,
                    AvatarUrl = model.AvatarUrl
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                    await userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Login");
                }
                else
                {
                    model.Message = "Something went wrong!";
                }
            }
            else
            {
                model.Message = "Username already exists!";
            }

            return View("Register", model);
        }
    }
}