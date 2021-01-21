using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Foxxit.Services.Interfaces;

namespace Foxxit.Models.Entities
{
    public abstract class PostBase : IIdentityEntity, ISoftDeletable
    {
        public PostBase()
        {
            Votes = new Collection<Vote>();
            Comments = new Collection<Comment>();
        }

        public long Id { get; set; }

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}