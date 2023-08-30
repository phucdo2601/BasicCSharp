using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SalaryManagement.Utility.Mail
{
    public class MailService
    {
        public static void SendMail(MailRequest mailRequest)
        {
            MailMessage mail = new();
            mail.To.Add(mailRequest.ToEmail);
            mail.From = new MailAddress(MailInfo.MAIL_SENDER);
            mail.Subject = mailRequest.Subject;
            mail.Body = mailRequest.Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new()
            {
                Port = MailInfo.MAIL_PORT,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Host = MailInfo.MAIL_HOST,
                Credentials = new NetworkCredential(MailInfo.MAIL_SENDER, MailInfo.MAIL_APP_PASSWORD)
            };
            smtp.Send(mail);
        }

        public static async Task<Response> SendMailBySendGrid(MailRequest mailRequest)
        {
            var apiKey = MailInfo.MAIL_API_KEY_SENDGRID;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(MailInfo.MAIL_SENDER, "FPT Lecturer's Assistant System");
            var subject = mailRequest.Subject;
            var to = new EmailAddress(mailRequest.ToEmail, mailRequest.ToEmail);
            var plainTextContent = mailRequest.Subject;
            var htmlContent = mailRequest.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response;
        }
    }
}
