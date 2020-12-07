using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Foxxit.Services
{
    public class UserService
    {
        private readonly SignInManager<User> signinManager;
        public UserService(SignInManager<User> signinManager)
        {
            this.signinManager = signinManager;
        }

        // public async Task<User> GetCurrentUser()
        // {
        //    var user = await signinManager.GetExternalLoginInfoAsync();
        //    return user;
        // }
    }
}
