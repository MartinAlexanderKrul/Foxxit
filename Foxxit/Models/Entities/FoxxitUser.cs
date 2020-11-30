using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Models.Entities
{
    public class FoxxitUser : IdentityUser
    {
        public string AvatarURL { get; set; }
        public string DisplayName { get; set; }
        
        //Exclude from DbSet in FluentAPI
        public int Karma
        {
            get { return VotesReceived.Select(v=>v.IsNegative==false).Count() 
                         - VotesReceived.Select(v=>v.IsNegative==true).Count(); }
        }
        public string About { get; set; }
        public DateTime CreatedAt { get; set; }
       
        //each user has many Posts
        public List<Post> Posts { get; set; }
        
        //each user has many SubReddits
        public ICollection<SubReddit> SubReddits { get; set; }
        
        //each user has received many Votes
        public List<Vote> VotesReceived { get; set; }
        
        //each user has given many Votes
        public List<Vote> VotesGiven { get; set; }
    }
}