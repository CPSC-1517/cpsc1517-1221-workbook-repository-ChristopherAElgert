using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        public void OnGet()
        {
            var gmailUserName = Configuration["GmailCreddentials:Username"];
            var gmailAppPassword = Configuration["GmailCreddentials:Password"];

            FeedbackMessage = $"Gmail Username = {gmailUserName} <br />";
            FeedbackMessage += $"Gmail Password = {gmailAppPassword} <br />";
        }
        private readonly IConfiguration Configuration;

        public SendMailModel(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [BindProperty]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Recipient { get; set; }

        [BindProperty]
        public string MailSubject { get; set; }

        [BindProperty]
        public string MailMessage { get; set; }


        public void OnPostSendMail()
        {
            //FeedbackMessage = "<h2>Send Mail button clicked</h2>";
      
            var sendMailClient = new SmtpClient();
            sendMailClient.Host = "smtp@gmail.com";
            sendMailClient.Port = 587;
            sendMailClient.EnableSsl = true;

            var sendMailCredentials = new NetworkCredential();
            //sendMailCredentials.UserName = Username;
            //sendMailCredentials.Password = Password;
            sendMailCredentials.UserName = Configuration["GmailCreddentials:Username"];
            sendMailCredentials.Password = Configuration["GmailCreddentials:Password"];
            sendMailClient.Credentials = sendMailCredentials;

            //var sendFromAddress = new MailAddress(Username);
            var sendFromAddress = new MailAddress(Configuration["GmailCreddentials:Username"]);
            var sendToAddress = new MailAddress(Recipient);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                FeedbackMessage = "<div class ='alert alert-primary'>Email Sent</div>";
            }
            catch (Exception ex)
            {
                FeedbackMessage = $"<div class ='alert alert-danger'>Error sending mail {ex}</div>";
            }
        }

        public void OnPostClearForm()
        {
            FeedbackMessage = "<h2>Clear Form button clicked</h2>";
            
        }
        
        public void OnPost()
        {

        }
    }
}
