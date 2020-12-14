using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Foxxit.Attributes.RoleServices;
using Foxxit.Database;
using Foxxit.Enums;
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
    public class AccountController : MainController
    {
        private readonly MailService mailService;
        private readonly ApplicationDbContext context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, MailService mailService)
            : base(userManager, signInManager)
        {
            this.mailService = mailService;
        }

        // Here - defaultly set as first login, then Index page. So must be set Login/Registration page as first now.
        [AuthorizedRoles(Enums.UserRole.Admin, Enums.UserRole.User)]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendEmailConfirmation(User user)
        {
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
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
                return RedirectToAction("index", "account");
            }

            var user = UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "The user ID {userId} is invalid");
                return View("Register");
            }

            var result = await UserManager.ConfirmEmailAsync(user.Result, token);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email cannot be confirmed.");
                return View("Register");
            }

            return View("EmailConfirmationSuccessful");
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

            var existingUser = await UserManager.FindByEmailAsync(model.Email);

            if (existingUser is null)
            {
                var user = new User(model.UserName, model.Email);
                var registerResult = await UserManager.CreateAsync(user, model.Password);

                if (registerResult.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, "User");

                    // await SendEmailConfirmation(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration went wrong!");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email is already taken!");
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

            var existingUser = await UserManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
            {
                var signInResult = await SignInManager.PasswordSignInAsync(existingUser, model.Password, model.RememberMe, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    // ModelState.AddModelError(string.Empty, "Your email was not approved!");
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
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        [HttpGet("external-login")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= "/account/index";
            var externalInfo = await SignInManager.GetExternalLoginInfoAsync();

            if (externalInfo is null)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while external information loading!");
                return View("Login");
            }

            var signInResult = await SignInManager.ExternalLoginSignInAsync(externalInfo.LoginProvider, externalInfo.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (!signInResult.Succeeded)
            {
                var email = externalInfo.Principal.FindFirstValue(ClaimTypes.Email);
                var username = externalInfo.Principal.FindFirstValue(ClaimTypes.Name);

                if (email != null || username != null)
                {
                    var user = email != null

                        ? await UserManager.FindByEmailAsync(email)
                        : await UserManager.FindByNameAsync(username);

                    if (user is null)
                    {
                        user = new User
                        {
                            UserName = email ?? username,
                            Email = email,
                        };

                        if (remoteError != null)
                        {
                            ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                            return View("Login");
                        }

                        var registerResult = await UserManager.CreateAsync(user);

                        if (registerResult.Succeeded)
                        {
                            await UserManager.AddToRoleAsync(user, "User");

                            return RedirectToAction("Login");
                        }
                        else
                        {
                            foreach (var error in registerResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }

                            return View("Login");
                        }
                    }

                    await UserManager.AddLoginAsync(user, externalInfo);
                    await SignInManager.SignInAsync(user, isPersistent: false);

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
            var changePasswordResult = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

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
            SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}