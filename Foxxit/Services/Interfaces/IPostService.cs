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
        IEnumerable<Post> HotSort(int hours, long? subRedditId);

        IEnumerable<Post> NewSort(long? subRedditId);

        IEnumerable<Post> Sort(SortMethod sortMethod, long? subRedditId);

        IEnumerable<Post> TopSort(int hours, long? subRedditId);
        Task<IEnumerable<Post>> GetAllIncludeCommentsAndUserAsync();

        Task<Post> GetByIdIncludeCommentsAndUserAsync(long id);
    }
}