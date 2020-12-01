using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Models.Entities
{
    public class UserModelxxx : IdentityUser
    {
        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }

        public UserModelxxx()
        {
        }

        public UserModelxxx(string userName = null)
        {
            UserName = userName;
        }
    }
}