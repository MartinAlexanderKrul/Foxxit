using System.IO;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;
using Microsoft.AspNetCore.Http;

namespace Foxxit.Services
{
    public class ImageService : GenericEntityService<Image>, IImageService
    {
        public ImageService(ImageRepository repository)
    : base(repository)
        {
            ImageRepository = repository;
        }

        public ImageRepository ImageRepository { get; private set; }

        public async Task<Image> GetByNameAsync(string name)
        {
            return await ImageRepository.GetByNameAsync(name);
        }

        public async Task<string> SaveImageAsync(IFormFile file)
        {
            if (file is null)
            {
                return null;
            }

            var image = new Image();
            var memory = new MemoryStream();
            var suffixIndex = file.FileName.LastIndexOf('.');

            image.Format = file.FileName[(suffixIndex + 1)..];
            file.CopyTo(memory);
            image.Stream = memory.ToArray();

            await AddAsync(image);
            await SaveAsync();

            return image.Name;
        }
    }
}