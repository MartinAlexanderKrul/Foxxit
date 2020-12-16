using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public interface INotificationService : IGenericEntityService<Notification>
    {
    }
}