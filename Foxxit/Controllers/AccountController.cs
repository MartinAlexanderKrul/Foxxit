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
        private readonly SignInManager<UserModelxxx> signInManager;
        private readonly UserManager<UserModelxxx> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<UserModelxxx> signInManager, UserManager<UserModelxxx> userManager, RoleManager<IdentityRole> roleManager)
        {
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

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var passwordCheck = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (passwordCheck.Succeeded)
                {
                    return RedirectToAction("Index", "Foxxit");
                }
                else
                {
                    model.Message = "Try to type your password again!";
                }
            }
            else
            {
                model.Message = "Username is not in database! Do you want to Sign Up?";
            }

            return View(model);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}