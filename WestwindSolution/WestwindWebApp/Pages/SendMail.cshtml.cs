using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Recipient { get; set; }

        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Message { get; set; }


        public void OnGet()
        {
            Username = "toasterknight@gmail.com";
            Password = "";
            Recipient = "raw_t0ast@hotmail.com";
            Subject = "Hi Me";
            Message = "Sending mail to yourself, pretty cringe I must say.";

            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smtp@gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;
            var sendMailCredentials = new NetworkCredential();
            sendMailCredentials.UserName = Username;
            sendMailCredentials.Password = Password;
            sendMailCredentials.Credentials = sendMailCredentials;

            var mailMessage = new MailMessage(sendFromAddress, sendToAdress);
            mailMessage.Subject = Subject;
            mailMessage.Body = Message;
            sendMailClient.Send(mailMessage);
        }
        public void OnPost()
        {

        }
    }
}
