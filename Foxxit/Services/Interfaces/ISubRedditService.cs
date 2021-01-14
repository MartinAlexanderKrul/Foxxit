using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface ISubRedditService : IGenericEntityService<SubReddit>
    {
        Task<IEnumerable<SubReddit>> GetAllIncludeUser();

        Task<SubReddit> GetbyIdIncludeUser(long id);
    }
}