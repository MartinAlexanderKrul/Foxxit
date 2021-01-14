using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public interface IUserService
    {
        Task UpdateUsernameAsync(User user, string newUserName);
    }
}