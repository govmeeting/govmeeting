using System.Threading.Tasks;

namespace GM.Application.AppCore.Interfaces
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
