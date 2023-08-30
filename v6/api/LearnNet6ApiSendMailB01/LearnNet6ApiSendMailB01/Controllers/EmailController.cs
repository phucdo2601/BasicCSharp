using LearnNet6ApiSendMailB01.Dtos;
using LearnNet6ApiSendMailB01.Services.EmailService;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace LearnNet6ApiSendMailB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService= emailService;
        }

        [HttpPost]
       /* public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("virginie.runte@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("virginie.runte@ethereal.email"));
            email.Subject =  "Test email subject";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("virginie.runte@ethereal.email", "2SgExCKCBc9DNgzghr");
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            return Ok();
        }*/

        public IActionResult SendEmail([FromBody] EmailDto request)
        {

            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
