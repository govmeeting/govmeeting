using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

        /*
        /// <summary>
                 /// Send email 
                 /// </summary>
                 /// <param name="sender"></param>
                 /// <param name="recepients"></param>
                 /// <param name="subject"></param>
                 /// <param name="body"></param>
                 /// <param name="isHtml"></param>
                 /// <param name="config"></param>
                 /// <returns></returns>
        public async Task<(bool success, string errorMsg)> SendEmailAsync(MailAddress sender, MailAddress[] recepients, string subject, string body, bool isHtml = true, MailAddress[] bccList = null)
        {
            MailMessage message = new MailMessage
            {
                From = sender
            };
            message.Subject = subject;
            message.IsBodyHtml = isHtml;
            message.Body = body;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            foreach (var recepient in recepients)
                message.To.Add(recepient);
            if (bccList != null)
            {
                foreach (var recepient in recepients)
                    message.Bcc.Add(recepient);
            }
            //var emailMessage = AddEmailMessageToStore(message);
            try
            {
                using (var client = new SmtpClient())
                {
                    var config = configService.EmailConfig;
                    if (config.EnableSSl)
                        client.EnableSsl = true;
                    client.Host = config.Host;
                    client.Port = config.Port;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential(config.UserName, rootConfig[config.PasswordConfigurationName]);
                    await client.SendMailAsync(message);
                    //emailMessage.IsSent = true;
                    //emailMessage.IsSuccessful = true;
                    //emailMessage.DateSent = DateTime.Now;
                    //emailMessage.DateModified = DateTime.Now;
                    //SaveEmailMessage(emailMessage);
                }
                return (true, null);
            }
            catch (Exception ex)
            {
                //if (loggerFactory != null)
                //    loggerFactory.CreateLogger<EmailSenderService>().LogError(LoggingEvents.SEND_EMAIL_ERROR, ex, "An error occurred while sending email");
                //emailMessage.IsSent = false;
                //emailMessage.IsSuccessful = false;
                //emailMessage.Comment = ex.ToString();
                //emailMessage.DateModified = DateTime.Now;
                //SaveEmailMessage(emailMessage);
                return (false, ex.Message);
            }
        }
        */
    }
}
