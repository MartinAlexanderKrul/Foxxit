using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Services
{
    public class MailService
    {
        private const string email = "foxxit2020@gmail.com";
        private const string name = "Foxxit Team";
        private const string registrationTemplateId = "d-eda73c0ba07a49d1bac1921215adda45";

        public async Task SendEmailAsync(string mailTo, object data)
        {
            var apiKey = Configuration.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var to = new EmailAddress(mailTo);
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, registrationTemplateId, data);
            await client.SendEmailAsync(msg);
        }
    }
}