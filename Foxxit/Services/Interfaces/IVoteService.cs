using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services.Interfaces
{
    public interface IVoteService : IGenericEntityService<Vote>
    {
        public int GetVoteValue(long userId, long postId);
    }
}
