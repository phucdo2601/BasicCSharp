using LNet7ApiPaginingB01.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LNet7ApiPaginingB01.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        dynamic GetEmployeePaging(string? searchQuery, int? pageNum, int? pageSize);
    }
}
