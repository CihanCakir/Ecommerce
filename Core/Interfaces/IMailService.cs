using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
        // Sipariş verildiği anda gönderilecek 
    }
}