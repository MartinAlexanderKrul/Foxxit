using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Enums;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IPostService : IGenericEntityService<Post>
    {
        public Task<IEnumerable<Post>> GetAllIncludeCommentsAsync();
        IEnumerable<Post> HotSort(int hours, int subRedditId);

        IEnumerable<Post> NewSort(int subRedditId);

        IEnumerable<Post> Sort(SortMethod sortMethod, int subRedditId = 0);

        IEnumerable<Post> TopSort(int hours, int subRedditId);
    }
}