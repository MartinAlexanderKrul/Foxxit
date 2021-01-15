using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class UserService : GenericEntityService<User>, IUserService
    {
        public UserService(UserRepository repository)
            : base(repository)
        {
        }

        public async Task UpdateUsernameAsync(User user, string newUserName)
        {
            user.UserName = newUserName;
            Update(user);
            await SaveAsync();
        }

        public async Task UpdateUsersSubReddits(User user, SubReddit subReddit)
        {
            var dbUser = await GetByIdAsync(user.Id);
            dbUser.CreatedSubReddits.Add(subReddit);
            Update(dbUser);
            await SaveAsync();
        }
    }
}