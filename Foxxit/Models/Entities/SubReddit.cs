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
        public long CreatedById { get; set; }
        public string CreatedByUserName { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Members { get; set; }
        public bool IsDeleted { get; set; }
    }
}