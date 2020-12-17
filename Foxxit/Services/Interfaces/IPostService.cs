using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IPostService : IGenericEntityService<Post>
    {
        IEnumerable<Post> HotSort(int hours);

        IEnumerable<Post> NewSort();

        IEnumerable<Post> Sort(string sortMethod);

        IEnumerable<Post> TopSort(int hours);
    }
}