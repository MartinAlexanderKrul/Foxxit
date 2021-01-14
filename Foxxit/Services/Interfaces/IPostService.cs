using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IPostService : IGenericEntityService<Post>
    {
        public Task<IEnumerable<Post>> GetAllIncludeCommentsAndUserAsync();
    }
}