using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GymManagementSystem.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(emailOptions.SendGridKey, subject, message, email);
        }

       private  Task Execute(string SendGridKEy,string subject,string message,string email)
        {
           
            var client = new SendGridClient(SendGridKEy);
            var from = new EmailAddress("gymprofitness336@gmail.com", "GymPro");
           
            var to = new EmailAddress(email, "End User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, "");
            return client.SendEmailAsync(msg);
        }
    }
}
