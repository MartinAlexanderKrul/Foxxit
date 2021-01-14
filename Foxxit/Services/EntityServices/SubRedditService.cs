using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class SubRedditService : GenericEntityService<SubReddit>, ISubRedditService
    {
        public SubRedditService(SubRedditRepository repository)
            : base(repository)
        {
            Repository = repository;
        }

        public new SubRedditRepository Repository { get; private set; }

        public async Task<IEnumerable<SubReddit>> GetAllIncludeUserAndMembers()
        {
            return await Repository.GetAllIncludeUserAndMembers();
        }

        public async Task<SubReddit> GetbyIdIncludeUserAndMembers(long id)
        {
            return await Repository.GetByIdIncludeUserAndMembers(id);
        }
    }
}