﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Enums;
using Foxxit.Models.Entities;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface IPostService : IGenericEntityService<Post>
    {
        IEnumerable<Post> HotSort(int hours);

        IEnumerable<Post> NewSort();

        IEnumerable<Post> Sort(SortMethod sortMethod);

        IEnumerable<Post> TopSort(int hours);
    }
}