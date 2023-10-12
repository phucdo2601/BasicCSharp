using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace LNet7ApiPaginingB01.Repositories.EmployeeRepository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AdventureWorks2022Context _dbContext;

        public EmployeeRepository(AdventureWorks2022Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employee = _dbContext.Employees.ToList();
            return employee;
        }
    }
}
