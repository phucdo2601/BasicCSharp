using SalaryManagement.Models;
using SalaryManagement.Requests.Login;
using SalaryManagement.Responses;
using System.Threading.Tasks;

namespace SalaryManagement.Services.LoginService
{
    public interface ILoginService
    {
        GeneralUserInfo AuthenticateUserByGmail(string gmail);
        GeneralUserInfo AuthenticateUser(string userName, string password);
        string GenerateJSONWebToken(GeneralUserInfo userInfo);
        string GenerateTokenForNewLecturer(string gmail);
        string GetGmailValidation(GmailLoginRequest gmailLoginDto);
        TokenResponse GetTokenResponse(GeneralUserInfo user);
        GeneralUserInfo GetUserById(string id);
        Task SendMailRegister(GeneralUserInfo user);
    }
}
