using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GM.WebApp.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        IConfiguration _config;

        public AuthMessageSender(IConfiguration config)
        {
            _config = config;
        }
        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    // Govmeeting: We put the stub code that Brock Allen used in his video to write the code to a file.
        //    File.AppendAllText(@"c:\tmp\WebbApp_email.txt", email + ", " + subject + ", " + message + "\r\n");
        //    return Task.FromResult(0);
        //}

        public Task SendSmsAsync(string number, string message)
        {
            // Govmeeting: Brock Allen's stub code
            File.AppendAllText(@"c:\tmp\WebbApp_sms.txt", number + ", " + message + "\r\n");
            return Task.FromResult(0);
        }

        // http://faq.asphosthelpdesk.com/article.php?id=83
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("info@govmeeting.org", "Govmeeting Info");
            mailMessage.From = fromAddress;
            MailAddress toAddress = new MailAddress(to);
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            try
            {
                using (var client = new SmtpClient())
                {
                    string username = _config["Email:Username"];
                    string password = _config["Email:Password"];
                    string host = _config["Email:Host"];
                    int port = Int32.Parse(_config["Email:Port"]);
                    string security = _config["Email:Security"];

                    client.Host = host;
                    client.Port = port;

                    //client.Credentials = CredentialCache.DefaultNetworkCredentials;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, password);
                    //client.EnableSsl = true;

                    await client.SendMailAsync(mailMessage);
                }
                //return (true, null);
            }
            catch (Exception ex)
            {
                // TODO: Use logging.
                Console.WriteLine("MessageServices.cs - Exception in SendEmailAsync: " + ex.Message);
                //return (false, ex.Message);
            }
        }

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
                    string username = _config["Email:Username"];
                    string password = _config["Email:Password"];
                    string host = _config["Email:Host"];
                    int port = Int32.Parse(_config["Email:Port"]);
                    string security = _config["Email:Security"];

                    // https://dotnetcoretutorials.com/2017/08/20/sending-email-net-core-2-0/
                    //SmtpClient client = new SmtpClient("mysmtpserver");
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, password);

                    //if (config.EnableSSl)
                    //    client.EnableSsl = true;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;

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
    }
}
