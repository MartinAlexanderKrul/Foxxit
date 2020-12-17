using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Foxxit.Services
{
    public class MailService : IMailService
    {
        private const string Email = "foxxit2020@gmail.com";
        private const string Name = "Foxxit Team";
        private const string RegistrationTemplateId = "d-eda73c0ba07a49d1bac1921215adda45";

        public async Task SendEmailAsync(string mailTo, object data)
        {
            var apiKey = Configuration.SendGridApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Email, Name);
            var to = new EmailAddress(mailTo);
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, RegistrationTemplateId, data);
            await client.SendEmailAsync(msg);
        }
    }
}