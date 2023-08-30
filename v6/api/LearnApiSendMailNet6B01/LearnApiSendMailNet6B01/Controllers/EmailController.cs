using LearnApiSendMailNet6B01.Dtos;
using LearnApiSendMailNet6B01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnApiSendMailNet6B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("sendMail")]
        public async Task<IActionResult> sendMailBasic([FromBody] EmailAddress emailAddress)
        {
            var message = new Message(new EmailAddress[] { 
            new EmailAddress
            {
                Address=emailAddress.Address,
                DisplayName=emailAddress.DisplayName
            }
            }, "Test email b02", "This is the content.");
            _emailSender.SendEmail(message);

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                Message = "Send Mail is successfully!"
            }));
        }

        [HttpPost("sendMailWithFile")]
        public async Task<IActionResult> SendMailWithFile() {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var message = new Message(new EmailAddress[] {
            new EmailAddress
            {
                Address="ngocphucdo2601@gmail.com",
                DisplayName="Phuc Do Ngoc"
            }
            }, "Test email", "This is the content from our email b02", files);

            _emailSender.SendMailWithFileAttach(message);
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                Message = "Send Mail with file is successfully!"
            }));
        }
    }
}
