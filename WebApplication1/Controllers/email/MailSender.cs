using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Controllers.email
{
    public class MailSender
    {

        public static bool SendEmail(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage(mailConstant.emailSender, email, subject, htmlMessage);
                SmtpClient client = new SmtpClient(mailConstant.hostEmail, mailConstant.portEmail);

                client.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential(mailConstant.emailSender, mailConstant.passwordSender);
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
