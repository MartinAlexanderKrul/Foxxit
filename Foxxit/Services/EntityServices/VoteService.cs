using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.Interfaces;

namespace Foxxit.Services.EntityServices
{
    public class VoteService : GenericEntityService<Vote>, IVoteService
    {
        public VoteService(VoteRepository repository)
            : base(repository)
        {
        }

        public int GetVotesValue(long userId, long postId)
        {
            var existingVotes = Repository.Filter(x => x.OwnerId == userId && x.PostBaseId == postId);
            int finalVote = 0;

            foreach (var vote in existingVotes)
            {
                finalVote += vote.Value;
            }

            return finalVote;
        }
    }
}
