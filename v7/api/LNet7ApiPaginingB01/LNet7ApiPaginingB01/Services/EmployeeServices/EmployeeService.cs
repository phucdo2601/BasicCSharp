using Azure;
using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace LNet7ApiPaginingB01.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdventureWorks2022Context _context;

        public EmployeeService(IUnitOfWork unitOfWork, AdventureWorks2022Context context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {
            try
            {
                var result = _unitOfWork.EmployeeRepository.GetAll().ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _unitOfWork.Dispose(); }
        }

        public dynamic GetEmployeePaging(string? searchQuery="", int? pageNum=1, int? pageSize =10)
        {
            try
            {
                if (!pageNum.HasValue)
                {
                    pageNum = 1;
                }
                if (!pageSize.HasValue)
                {
                    pageSize = 10;
                }

                var employees = new Object();
                double pageCount = 0f;
                var totalsRecords = 0f;


                if (searchQuery.IsNullOrEmpty())
                {
                    employees = _context.Employees
                    .Skip((int)((pageNum - 1) * pageSize))
                    .Take((int)pageSize)
                    .ToList();

                     pageCount = Math.Ceiling((double)(_context.Employees.Count() / pageSize));

                    totalsRecords = _context.Employees.Count();
                } else
                {
                    employees = _context.Employees
                        .Where(x => x.JobTitle.Contains(searchQuery))
                    .Skip((int)((pageNum - 1) * pageSize))
                    .Take((int)pageSize)
                    .ToList();

                    totalsRecords = _context.Employees.Where(x => x.JobTitle.Contains(searchQuery)).Count();
                    pageCount = Math.Ceiling((double)(totalsRecords / pageSize));
                    
                }

                
                var response = new 
                {
                    Employees = employees,
                    CurrentPage = pageNum,
                    PageSizes = pageSize,
                    Pages = (double)pageCount,
                    TotalRecords = (int) totalsRecords,
                };
                return response;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _unitOfWork.Dispose(); }
        }
    }
}
