using System.Collections.Generic;
using System.Linq;
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

        public async Task<Vote> AddNewVote(long userId, long postBaseId, int value)
        {
            var votes = Repository.Filter(x => x.OwnerId == userId && x.PostBaseId == postBaseId);

            var newVote = new Vote() { OwnerId = userId, PostBaseId = postBaseId, Value = value };

            await Repository.AddAsync(newVote);

            return newVote;
        }

        public Vote GetVote(long userId, long postBaseId)
        {
            return Repository
                .Filter(x => x.OwnerId == userId && x.PostBaseId == postBaseId)
                .FirstOrDefault();
        }

        public int GetKarma(long postBaseId)
        {
            return Repository
                .Filter(v => v.PostBaseId == postBaseId)
                .Sum(v => v.Value);
        }

        public async Task EnsureOneVote(Vote newVote)
        {
            var existingVotes = Repository.Filter(v => v.Id != newVote.Id && v.PostBaseId == newVote.PostBaseId && v.OwnerId == newVote.OwnerId);
            foreach (Vote vote in existingVotes)
            {
                Repository.Delete(vote);
            }

            await Repository.SaveAsync();
        }
    }
}
