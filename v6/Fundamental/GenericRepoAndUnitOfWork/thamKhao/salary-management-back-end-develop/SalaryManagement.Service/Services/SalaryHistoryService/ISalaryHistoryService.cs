using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.SalaryHistoryService
{
    public interface ISalaryHistoryService
    {
        List<SalaryHistory> GetSalaryHistories();
        SalaryHistory GetSalaryHistory(string salaryHistoryId);
        List<SalaryHistory> GetSalaryHistoriesOfLecturer(string lecturerId);
        int CreateSalaryHistory(string salaryHistoryId, SalaryHistoryRequest salaryHistoryRequest);
        int UpdateSalaryHistory(string id, SalaryHistoryRequest salaryHistoryRequest);
        int ChangeUsingSalaryHistory(string salaryHistoryId, bool status);
        JObject GetSalaryHistoryList(Pagination pagination, bool? isUsing);
        JObject GetLecturerHistory(string lecturerId, Pagination pagination, bool? isUsing);
    }
}
