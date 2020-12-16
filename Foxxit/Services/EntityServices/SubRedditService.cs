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
        public SubRedditService(GenericRepository<SubReddit> repository)
            : base(repository)
        {
        }
    }
}