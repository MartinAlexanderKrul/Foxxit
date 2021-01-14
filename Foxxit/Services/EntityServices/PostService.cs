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
            PostRepository = repository;
        }

        public PostRepository PostRepository { get; private set; }

        public async Task<IEnumerable<Post>> GetAllIncludeCommentsAsync()
        {
            return await PostRepository.GetAllIncludeCommentsAsync();
        }

        public IEnumerable<Post> Sort(SortMethod sortMethod, int subRedditId = 0)
        {
            switch (sortMethod)
            {
                case SortMethod.Hot:
                    return HotSort(24, subRedditId);

                case SortMethod.New:
                    return NewSort(subRedditId);

                case SortMethod.Top:
                    return TopSort(168, subRedditId);

                default:
                    return HotSort(24, subRedditId);
            }
        }

        public IEnumerable<Post> HotSort(int hours, int subRedditId)
        {
            var filter = Filter(p => (DateTime.Now - p.CreatedAt).TotalHours < hours).OrderBy(p => p.Votes.Count);
            if (subRedditId != 0)
            {
                return filter.Where(p => p.SubRedditId == subRedditId);
            }

            return filter;
        }

        public IEnumerable<Post> NewSort(int subRedditId)
        {
            return subRedditId == 0 ? GetAllAsync().Result.OrderBy(p => p.CreatedAt) : Filter(p => p.SubReddit.Id == subRedditId).OrderBy(p => p.CreatedAt);
        }

        public IEnumerable<Post> TopSort(int hours, int subRedditId)
        {
            return HotSort(hours, subRedditId);
        }
    }
}