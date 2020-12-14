using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foxxit.Services.Interfaces;

namespace Foxxit.Models.Entities
{
    public class SubReddit : IIdentityEntity, ISoftDeletable
    {
        public SubReddit()
        {
            Posts = new Collection<Post>();
            Members = new Collection<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime CreatedAt { get; set; }

        // each SubReddit has one Creator/Owner
        public long CreatedById { get; set; }

        // each SubReddit has many posts
        public ICollection<Post> Posts { get; set; }

        // each SubReddit has many members
        public ICollection<User> Members { get; set; }

        public bool IsDeleted { get; set; }
    }
}