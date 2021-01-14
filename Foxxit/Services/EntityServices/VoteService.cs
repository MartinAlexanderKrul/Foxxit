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

        public async void AddNewVote(long userId, long postBaseId, int value)
        {
            var votes = Repository.Filter(x => x.OwnerId == userId && x.PostBaseId == postBaseId);

            foreach (var vote in votes)
            {
                Repository.Delete(vote);
            }

            var newVote = new Vote() { OwnerId = userId, PostBaseId = postBaseId, Value = value };
            await Repository.AddAsync(newVote);
            await Repository.SaveAsync();
        }

        public int GetVoteValue(long userId, long postBaseId)
        {
            return Repository
                .Filter(x => x.OwnerId == userId && x.PostBaseId == postBaseId)
                .First().Value;
        }

        public int GetVotesCount(long postBaseId)
        {
            return Repository
                .Filter(x => x.PostBaseId == postBaseId)
                .Count();
        }

    }
}
