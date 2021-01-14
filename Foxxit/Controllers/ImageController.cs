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

        [HttpGet("upload-image")]
        public IActionResult Image()
        {
            return View("Image");
        }

        [HttpGet("imagestore/{name}")]
        public async Task<FileStreamResult> Imagestore([FromRoute] string name)
        {
            var image = await ImageService.GetByNameAsync(name);
            var stream = new MemoryStream(image.Stream);
            return new FileStreamResult(stream, $"image/{image.Format}");
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveImage(IFormFile upload, Image image, MemoryStream memory)
        {
            var suffixIndex = upload.FileName.LastIndexOf('.');
            image.Format = upload.FileName[(suffixIndex + 1)..];

            upload.CopyTo(memory);
            image.Stream = memory.ToArray();

            await ImageService.AddAsync(image);
            await ImageService.SaveAsync();

            return RedirectToAction("Image");
        }
    }
}