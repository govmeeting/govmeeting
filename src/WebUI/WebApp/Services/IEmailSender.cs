using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
