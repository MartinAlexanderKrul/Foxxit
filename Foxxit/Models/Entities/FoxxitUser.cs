using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Models.Entities
{
    public class FoxxitUser : IdentityUser
    {
        public string AvatarURL { get; set; }
        public string DisplayName { get; set; }
        public int Karma
        {
            get { return VotesReceived.Count; }
            set { }
        }
        public string About { get; set; }
        public DateTime MemberSince { get; set; }
       
        //each user has many Posts
        public List<Post> Posts { get; set; }
        
        //each user has many SubReddits
        public List<SubReddit> SubReddits { get; set; }
        
        //each user has received many Votes
        public List<Vote> VotesReceived { get; set; }
        
        //each user has given many Votes
        public List<Vote> VotesGiven { get; set; }
    }
}