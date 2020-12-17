using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Enums;
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

        public IEnumerable<Post> Sort(string sortMethod)
        {
            switch (sortMethod)
            {
                case nameof(SortMethod.Hot):
                    return HotSort(24);

                case nameof(SortMethod.New):
                    return NewSort();

                case nameof(SortMethod.Top):
                    return TopSort(168);

                default:
                    return HotSort(24);
            }
        }

        public IEnumerable<Post> HotSort(int hours)
        {
            return Filter(p => (DateTime.Now - p.CreatedAt).TotalHours < hours).OrderByDescending(p => p.Votes.Count);
        }

        public IEnumerable<Post> NewSort()
        {
            return GetAllAsync().Result.OrderByDescending(p => p.CreatedAt);
        }

        public IEnumerable<Post> TopSort(int hours)
        {
            return HotSort(hours);
        }
    }
}