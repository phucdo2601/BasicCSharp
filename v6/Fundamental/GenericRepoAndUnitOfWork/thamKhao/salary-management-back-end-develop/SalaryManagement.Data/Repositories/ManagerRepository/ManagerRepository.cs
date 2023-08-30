using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        private readonly SalaryConfirmContext _context;

        public ManagerRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
