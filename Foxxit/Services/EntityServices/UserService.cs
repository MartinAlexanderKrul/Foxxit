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
    }
}