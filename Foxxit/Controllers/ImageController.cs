using System.IO;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ImageController : MainController
    {
        public ImageController(UserManager<User> userManager, SignInManager<User> signInManager, IImageService imageService)
            : base(userManager, signInManager)
        {
            ImageService = imageService;
        }

        public IImageService ImageService { get; }

        [HttpGet("imagestore/{name}")]
        public async Task<FileStreamResult> Imagestore([FromRoute] string name)
        {
            var image = await ImageService.GetByNameAsync(name);
            var stream = new MemoryStream(image.Stream);
            return new FileStreamResult(stream, $"image/{image.Format}");
        }
    }
}