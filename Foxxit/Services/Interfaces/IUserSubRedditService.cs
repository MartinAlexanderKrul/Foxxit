using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IUserSubRedditService : IGenericEntityService<UserSubReddit>
    {
        UserSubReddit GetByOthersId(long subRedditId, long userId);

        Task Delete(long subRedditId, long userId);
    }
}