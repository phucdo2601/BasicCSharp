using LearnNet6ApiSendMailB01.Dtos;

namespace LearnNet6ApiSendMailB01.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto emailDto);
    }
}
