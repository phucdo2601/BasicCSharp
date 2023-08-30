using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryManagement.Services.UserService
{
    public interface IUserService
    {
        List<JObject> GetUserInfos();
        JObject GetUserById(string userId);
        int DisableUser(string id, bool status);
        int CreateUser(string userId, UserRequest userRequest);
        JObject GetUsers(Pagination pagination, bool? isDisable);
        List<GeneralUserInfo> GetUsersByName(string name);
        int UpdatePasswordUser(string id, UserPasswordRequest userPasswordRequest);
        Task<string> SendMailForgotPassword(string generalUserInfoId);
    }
}
