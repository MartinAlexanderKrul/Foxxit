using System.Threading.Tasks;
using Foxxit.Models;
using Foxxit.Models.Entities;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    var user = new User { };

        //    // ...
        //    // if (result.Succeeded)
        //    //{
        //    await SendEmailConfirmation(user);
        //    //}
        //}

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
    }
}
