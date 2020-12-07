using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Repositories;

namespace Foxxit.Services
{
    public class UserService
    {
        public UserService(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public UserRepository UserRepository { get; set; }
    }
}