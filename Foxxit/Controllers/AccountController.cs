﻿using System.Security.Claims;
using System.Threading.Tasks;
using Foxxit.Models;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Route("[controller]")]
    public class AccountController : GeneralController
    {
        private readonly MailService mailService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, MailService mailService)
            : base(userManager, signInManager)
        {
            this.mailService = mailService;
        }

        [Authorize]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmailConfirmation(User user)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

            var data = new RegistrationEmailData(confirmationLink, user.UserName);

            await mailService.SendEmailAsync(user.Email, data);

            return View("ConfirmRegistration");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user ID {userId} is invalid";
                return View("Error");
            }

            var result = await userManager.ConfirmEmailAsync(user.Result, token);

            if (!result.Succeeded)
            {
                ViewBag.ErrorMessage = "Email cannot be confirmed.";
                return View("Error");
            }

            return View("EmailConfirmationSuccessful");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await userManager.FindByNameAsync(model.UserName);

            if (existingUser is null)
            {
                var user = new User(model.UserName);
                var registerResult = await userManager.CreateAsync(user, model.Password);

                if (registerResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    await SendEmailConfirmation(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration went wrong!");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username already exists!");
            }

            return View(model);
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

            var existingUser = await userManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
            {
                var signInResult = await signInManager.PasswordSignInAsync(existingUser, model.Password, model.RememberMe, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Try to type your password again!");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username is not in database! Do you want to Sign Up?");
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
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            returnUrl ??= "/account/index";
            var externalInfo = await signInManager.GetExternalLoginInfoAsync();

            if (externalInfo is null)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while external information loading!");
                return View("Login");
            }

            var signInResult = await signInManager.ExternalLoginSignInAsync(externalInfo.LoginProvider, externalInfo.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (!signInResult.Succeeded)
            {
                var email = externalInfo.Principal.FindFirstValue(ClaimTypes.Email);
                var username = externalInfo.Principal.FindFirstValue(ClaimTypes.Name);

                if (email != null || username != null)
                {
                    var user = username != null
                        ? await userManager.FindByNameAsync(username)
                        : await userManager.FindByEmailAsync(email);

                    if (user is null)
                    {
                        user = new User
                        {
                            UserName = username ?? email,
                            Email = email,
                        };

                        var registerResult = await userManager.CreateAsync(user);

                        if (registerResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "User");

                            return RedirectToAction("Login");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "External registration went wrong!");
                        }
                    }

                    await userManager.AddLoginAsync(user, externalInfo);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Email or username claim not received!");
                return View("Login");
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
            {
                return View(model);
            }

            var user = await GetActiveUserAsync();
            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (changePasswordResult.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Password was not changed!");
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