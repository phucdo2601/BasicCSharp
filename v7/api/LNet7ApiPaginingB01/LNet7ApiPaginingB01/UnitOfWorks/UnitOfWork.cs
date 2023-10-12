using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.Repositories.EmployeeRepository;

namespace LNet7ApiPaginingB01.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdventureWorks2022Context _context;

        public UnitOfWork(AdventureWorks2022Context context)
        {
            _context = context;
        }

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
               return _context.SaveChanges();
        }
    }
}
