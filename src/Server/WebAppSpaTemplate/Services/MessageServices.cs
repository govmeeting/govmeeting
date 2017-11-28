using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Govmeeting: We put the stub code that Brock Allen used in his video to write the code to a file.
            File.AppendAllText(@"c:\tmp\WebbApp_email.txt", email + ", " + subject + ", " + message + "\r\n");
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Govmeeting: Brock Allen's stub code
            File.AppendAllText(@"c:\tmp\WebbApp_sms.txt", number + ", " + message + "\r\n");
            return Task.FromResult(0);
        }
    }
}
