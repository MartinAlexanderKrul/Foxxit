using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Models.Entities
{
    public class FoxxitUser : IdentityUser
    {
        public string AvatarURL { get; set; }
        public string DisplayName { get; set; }
        
        public int Karma { get; set; }
        public string About { get; set; }
        public DateTime CreatedAt { get; set; }
       
        //each user has many Posts
        public ICollection<Post> Posts { get; set; }
        
        //each user has many SubReddits
        public ICollection<SubReddit> SubReddits { get; set; }

        //each user has given many Votes
        public ICollection<Vote> Votes { get; set; }
        
        //each user has many comments
        public ICollection<Comment> Comments { get; set; }

        public FoxxitUser()
        {
            Posts=new Collection<Post>();
            SubReddits=new Collection<SubReddit>();
            Votes=new Collection<Vote>();
            Comments=new Collection<Comment>();
        }
    }
}