﻿using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    public class AccountController : Controller
    {
        private readonly MailService mailService;
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager, MailService mailService)
        {
            this.userManager = userManager;
            this.mailService = mailService;
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User { };

            // ...
            // if (result.Succeeded)
            //{
            var token = await userManager.GenerateChangeEmailTokenAsync(user, user.Email);
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

            string content = $"<h1>Please confirm your registration.</h1><p><a href=\"{confirmationLink}\">Click here</a></p>";
            await mailService.SendEmailAsync(model.Email, "Please confim your email.", content);

            return View("ConfirmRegistration");
            //}
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

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                ViewBag.ErrorMessage = "Email cannot be confirmed.";
                return View("Error");
            }

            return View("EmailConfirmationSuccessful");
        }
    }
}
