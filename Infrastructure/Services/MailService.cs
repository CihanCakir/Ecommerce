using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }
        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var owner = _config["SendGrid:Mail"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@authdemo.com", "Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            return client.SendEmailAsync(msg);


        }
    }
}