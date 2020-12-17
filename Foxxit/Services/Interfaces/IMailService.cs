using System.Threading.Tasks;

namespace Foxxit.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string mailTo, object data);
    }
}