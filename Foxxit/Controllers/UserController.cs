using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.DTO;
using Foxxit.Models.Entities;
using Foxxit.Models.ViewModels;
using Foxxit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Route("user")]
    public class UserController : MainController
    {
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, INotificationService notificationService, ISubRedditService subRedditService)
            : base(userManager, signInManager)
        {
            NotificationService = notificationService;
            SubRedditService = subRedditService;
        }

        public INotificationService NotificationService { get; private set; }
        public ISubRedditService SubRedditService { get; private set; }

        [HttpGet("notifications")]
        public async Task<IActionResult> Notifications()
        {
            var model = new MainPageViewModel() /* {CurrentUser = await GetActiveUserAsync()}*/;

            return View("Notifications", model);
        }

        [HttpGet("readNotification/{notificationId}")]
        public async Task<IActionResult> ReadNotification(long notificationId)
        {
            await NotificationService.MarkNotificationRead(await NotificationService.GetByIdAsync(notificationId));
            var model = new MainPageViewModel();

            return RedirectToAction("ViewPost", "Foxxit", notificationId); // TODO: Change action and controller name according to the actual post route
        }
    }
}