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
        public string templateId;

        public MailService()
        {
            email = "foxxit20020@gmail.com";
            name = "Foxxit Team";
            templateId = "d-eda73c0ba07a49d1bac1921215adda45";
        }

        public async Task SendEmailAsync(string mailTo, object dynamicTemplateData)
        {
            var apiKey = Configuration.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var to = new EmailAddress(mailTo);
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
            await client.SendEmailAsync(msg);
        }
    }
}