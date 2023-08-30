using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.ManagerService
{
    public interface IManagerService
    {
        List<JObject> GetExaminationManagers();
        List<JObject> GetHRManagers();
        GeneralUserInfo GetManagerById(string userId);
        List<JObject> GetManagerByName(string name);
        int DisableManager(string id, bool status);
        int CreateManager(string managerId, ManagerRequest managerRequest);
        int UpdateManager(string id, ManagerUpdateRequest managerRequest);
        JObject GetManagerList(Pagination pagination, bool? isDisable);
    }
}
