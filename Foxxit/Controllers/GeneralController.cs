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
    public class GeneralController : Controller
    {
        protected readonly UserManager<User> userManager;
        protected readonly SignInManager<User> signInManager;

        public GeneralController(UserManager<User> userManager, SignInManager<User> signInManager)
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