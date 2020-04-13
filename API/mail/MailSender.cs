using System;
using System.Threading.Tasks;
using Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace API.mail
{
    public class MailSender : IMailService
    {
        private const string SendGridKey = "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";

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            return Execute(SendGridKey, toEmail, subject, content);
        }

        private Task Execute(string sendGridKey, string toEmail, string subject, string content)
        {
            var client = new SendGridClient(sendGridKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("info@shopapp.com", "Shop App"),
                Subject = subject,
                PlainTextContent = content,
                HtmlContent = content
            };

            msg.AddTo(new EmailAddress(toEmail));
            return client.SendEmailAsync(msg);
        }
    }
}