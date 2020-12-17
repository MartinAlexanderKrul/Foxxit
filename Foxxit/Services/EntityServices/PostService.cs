using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class PostService : GenericEntityService<Post>, IPostService
    {
        public PostService(PostRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<Post> HotSort(int hours)
        {
            return Filter(p => (DateTime.Now - p.CreatedAt).TotalHours < hours).OrderByDescending(p => p.Votes.Count);
        }

        public IEnumerable<Post> NewSort()
        {
            return GetAllAsync().Result.OrderByDescending(p => p.CreatedAt);
        }

        public IEnumerable<Post> TopSort()
        {
            return HotSort(168);
        }
    }
}