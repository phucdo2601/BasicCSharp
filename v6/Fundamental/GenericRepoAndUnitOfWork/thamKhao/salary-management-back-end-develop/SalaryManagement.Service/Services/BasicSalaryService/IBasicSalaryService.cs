using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.BasicSalaryService
{
    public interface IBasicSalaryService
    {
        List<BasicSalary> GetBasicSalaries();
        BasicSalary GetBasicSalary(string salaryBasicId);
        int DisableBasicSalary(string salaryBasicId, bool status);
        int CreateBasicSalary(string basicSalaryId, BasicSalaryRequest basicSalaryRequest);
        int UpdateBasicSalary(string id, BasicSalaryRequest basicSalaryRequest);
        int UpdateBSalaryLecturer(BasicSalaryLecturer basicSalaryLecturer);
        JObject GetSalaries(Pagination pagination, bool? isDisable);
        List<BasicSalary> GetBasicSalariesByName(string level);
    }
}
