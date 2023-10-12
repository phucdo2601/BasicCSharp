using LNet7ApiPaginingB01.Repositories.EmployeeRepository;

namespace LNet7ApiPaginingB01.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        int Save();
    }
}
