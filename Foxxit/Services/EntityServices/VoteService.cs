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
    }
}
