using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.AdminService
{
    public interface IAdminService
    {
        List<JObject> GetAdminInfos();
        GeneralUserInfo GetAdminById(string adminId);
        int DisableAdmin(string id, bool status);
        int CreateAdmin(string adminId, AdminRequest adminRequest);
        int UpdateAdmin(string id, AdminUpdateRequest adminRequest);
        int UpdatePasswordAdmin(string id, UserPasswordRequest userPasswordRequest);
        JObject GetAdmins(Pagination pagination, bool? isDisable);
        List<JObject> GetAdminsByName(string name);
    }
}
