using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using Foxxit.Models;

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

        [Authorize]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
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
                return View(model);
            }

            var existingUser = await userManager.FindByNameAsync(model.UserName);

            if (existingUser == null)
            {
                var user = new UserModelxxx(model.UserName);
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
                return View(model);

            var existingUser = await userManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
            {
                var passwordCheck = await signInManager.PasswordSignInAsync(existingUser, model.Password, model.RememberMe, false);

                if (passwordCheck.Succeeded)
                {
                    return RedirectToAction("PasswordChange", "Account");
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

        [HttpPost("external-login")]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        [HttpGet("external-login")]
        public async Task<IActionResult> ExternalLoginCallback(UserModelxxx user, LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= "/account/index";
            var externalInfo = await signInManager.GetExternalLoginInfoAsync();

            if (externalInfo is null)
            {
                model.Message = "Something went wrong while external information loading!";
                return View("Login", model);
        }

            var signInResult = await signInManager.ExternalLoginSignInAsync(externalInfo.LoginProvider, externalInfo.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (!signInResult.Succeeded)
            {
                var email = externalInfo.Principal.FindFirstValue(ClaimTypes.Email);
                var username = externalInfo.Principal.FindFirstValue(ClaimTypes.Name);

                if (email != null || username != null)
                {
                    user = username != null
                        ? await userManager.FindByNameAsync(username)
                        : await userManager.FindByEmailAsync(email);

                    if (user is null)
        {
                        user = new UserModelxxx
            {
                            UserName = username ?? email,
                            Email = email
                        };

                        await userManager.CreateAsync(user);
                        await roleManager.CreateAsync(new IdentityRole("User"));
                        await userManager.AddToRoleAsync(user, "User");
                    }

                    await userManager.AddLoginAsync(user, externalInfo);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                model.Message = "Email or username claim not received!";
                return View("Login", model);
            }

            return LocalRedirect(returnUrl);
        }

        [Authorize]
        [HttpGet("passwordchange")]
        public IActionResult PasswordChange()
            {
            return View();
            }

        [Authorize]
        [HttpPost("passwordchange")]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                model.Message = "Something went wrong!";
            }

            return View(model);
            }

        [Authorize]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
