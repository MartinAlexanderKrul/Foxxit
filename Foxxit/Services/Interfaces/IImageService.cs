using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IImageService : IGenericEntityService<Image>
    {
        Task<Image> GetByNameAsync(string name);
    }
}