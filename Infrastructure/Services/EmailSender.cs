using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public AuthSenderOptions Options { get; }

        public EmailSender(IOptions<AuthSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGrid.SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                //This must match verified email address in sendgrid
                From = new EmailAddress("amberspatig@mail.weber.edu", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(true, true);

            return client.SendEmailAsync(msg);
        }
    }
}
