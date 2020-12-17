using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Models.Entities
{
    public class User : IdentityUser<long>, IIdentityEntity, ISoftDeletable
    {
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
            Posts = new Collection<Post>();
            SubReddits = new Collection<SubReddit>();
            Votes = new Collection<Vote>();
            Comments = new Collection<Comment>();
            ReceivedNotifications = new Collection<Notification>();
            GivenNotifications = new Collection<Notification>();
        }

        public User()
        {
            Posts = new Collection<Post>();
            SubReddits = new Collection<SubReddit>();
            Votes = new Collection<Vote>();
            Comments = new Collection<Comment>();
            ReceivedNotifications = new Collection<Notification>();
            GivenNotifications = new Collection<Notification>();
        }

        public string AvatarURL { get; set; }
        public string DisplayName { get; set; }
        public int Karma { get; set; }
        public string About { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<SubReddit> SubReddits { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Notification> ReceivedNotifications { get; set; }
        public ICollection<Notification> GivenNotifications { get; set; }
        public bool IsDeleted { get; set; }
    }
}