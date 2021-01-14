using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface ICommentService : IGenericEntityService<Comment>
    {
        Task<Comment> GetByIdInclude(long id);
    }
}