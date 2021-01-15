using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class UserSubRedditService : GenericEntityService<UserSubReddit>, IUserSubRedditService
    {
        public UserSubRedditService(UserSubRedditRepository repository)
            : base(repository)
        {
            Repository = repository;
        }

        public new UserSubRedditRepository Repository { get; private set; }

        public UserSubReddit GetByOthersId(long subRedditId, long userId)
        {
            return Repository.GetByOthersId(subRedditId, userId);
        }

        public async Task Delete(long subRedditId, long userId)
        {
            await Repository.Delete(subRedditId, userId);
        }
    }
}