using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foxxit.Services.Interfaces;

namespace Foxxit.Models.Entities
{
    public class SubReddit : IIdentityEntity, ISoftDeletable
    {
        public SubReddit(string name, string about, long createdById)
        {
            Name = name;
            About = about;
            CreatedById = createdById;
        }

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
        public User CreatedBy { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<User> Members { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
    }
}