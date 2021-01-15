using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services.Interfaces
{
    public interface IVoteService : IGenericEntityService<Vote>
    {
        public Vote GetVote(long userId, long postId);
        public Task<Vote> AddNewVote(long userId, long postBaseId, int value)
;
        public int GetVotesSum(long postBaseId);
    }
}
