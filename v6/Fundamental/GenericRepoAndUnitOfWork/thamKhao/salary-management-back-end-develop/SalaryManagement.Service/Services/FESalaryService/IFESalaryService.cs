using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.FESalaryService
{
    public interface IFESalaryService
    {
        List<Fesalary> GetFESalaries();
        Fesalary GetFesalary(string id);
        int DisableFesalary(string id, bool status);
        int CreateFesalary(string fesalaryId, FESalaryRequest fESalaryRequest);
        int UpdateFesalary(string id, FESalaryRequest fESalaryRequest);
        int UpdateFesalaryLecturer(FESalaryLecturer fESalaryLecturer);
        JObject GetFESalaryList(Pagination pagination, bool? isDisable);
        List<Fesalary> GetFESalariesByCode(string code);
    }
}
