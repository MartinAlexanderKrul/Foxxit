using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;
using Microsoft.AspNetCore.Http;

namespace Foxxit.Services
{
    public interface IImageService : IGenericEntityService<Image>
    {
        Task<Image> GetByNameAsync(string name);

        Task<string> SaveImageAsync(IFormFile file);
    }
}