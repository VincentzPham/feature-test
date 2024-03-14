using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace EduPost.Controllers
{
    public class MailSender : IEmailSender
    {

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage("test",email,subject,htmlMessage);
                SmtpClient client = new SmtpClient("", 0);
                
                client.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential("", "");
                client.UseDefaultCredentials = false;
                client.Credentials = credential;
                client.Send(message);
                return Task.CompletedTask;
            }
            catch
            {
                return Task.CompletedTask;
            }
        }
    }
}
