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
        public string email;
        public string name;

        public MailService()
        {
            email = "foxxit20020@gmail.com";
            name = "Foxxit Team";
        }

        public async Task SendEmailAsync(string mailTo, string subject, string content)
        {
            var apiKey = Configuration.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var to = new EmailAddress(mailTo);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}