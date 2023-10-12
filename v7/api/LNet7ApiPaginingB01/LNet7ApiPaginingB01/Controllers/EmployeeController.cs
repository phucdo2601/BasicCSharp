using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.Services.EmployeeServices;
using LNet7ApiPaginingB01.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LNet7ApiPaginingB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;
        private readonly AdventureWorks2022Context _context;

        public EmployeeController(IUnitOfWork unitOfWork, AdventureWorks2022Context context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            this._employeeService = new EmployeeService(unitOfWork, context);
        }

        [HttpGet("getAllEmployess")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAllEmployees();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, employees));
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllEmployees([FromQuery(Name ="searchParams")]  string? searchQuery, [FromQuery(Name = "pageNum")] int? pageNum, [FromQuery(Name = "pageSize")] int? pageSize)
        {
            var employees = _employeeService.GetEmployeePaging(searchQuery, pageNum, pageSize);
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, employees));
        }
    }
}
