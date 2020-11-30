using System;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Models.Entities
{
    public class FoxxitUser : IdentityUser
    {
        public string AvatarURL { get; set; }
        public string DisplayName { get; set; }
        public int Karma { get; set; }
        public string About { get; set; }
        public DateTime MemberSince { get; set; }
    }
}