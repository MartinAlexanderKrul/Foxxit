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
        public IFormFile File { get; set; }

        public async Task<Image> GetByNameAsync(string name)
        {
            return await ImageRepository.GetByNameAsync(name);
        }
    }
}