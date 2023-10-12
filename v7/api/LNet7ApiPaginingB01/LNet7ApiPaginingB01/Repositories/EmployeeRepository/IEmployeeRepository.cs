using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.Repositories.GenericRepository;

namespace LNet7ApiPaginingB01.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
