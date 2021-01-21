using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    public class MainController : Controller
    {
        public MainController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; protected set; }
        public SignInManager<User> SignInManager { get; protected set; }

        protected virtual async Task<User> GetActiveUserAsync()
        {
            var userId = UserManager.GetUserId(User);
            return await UserManager.FindByIdAsync(userId);
        }
    }
}
