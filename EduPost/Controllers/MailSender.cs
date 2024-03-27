using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace EduPost.Controllers
{
    public class MailSender
    {

        public static bool SendEmail(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage(MailConstant.emailSender, email, subject, htmlMessage);
                SmtpClient client = new SmtpClient(MailConstant.hostEmail, MailConstant.portEmail);

                client.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential(MailConstant.emailSender, MailConstant.passwordSender);
                client.UseDefaultCredentials = false;
                client.Credentials = credential;
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
