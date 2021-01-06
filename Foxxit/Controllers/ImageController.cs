using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foxxit.Controllers
{
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
        public async Task<IActionResult> ImageAsync()
        {
            var images = await ImageService.GetAllAsync();
            var image = images.Last();
            ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(image.Stream, 0, image.Stream.Length);

            return View("Image");
        }

        [HttpGet("imagestore/{id}")]
        public async Task<FileStreamResult> Imagestore([FromRoute] long id)
        {
            var image = await ImageService.GetByIdAsync(id);
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