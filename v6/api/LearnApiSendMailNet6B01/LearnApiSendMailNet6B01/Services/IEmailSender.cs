using LearnApiSendMailNet6B01.Dtos;

namespace LearnApiSendMailNet6B01.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);

        void SendMailWithFileAttach(Message message);
    }
}
