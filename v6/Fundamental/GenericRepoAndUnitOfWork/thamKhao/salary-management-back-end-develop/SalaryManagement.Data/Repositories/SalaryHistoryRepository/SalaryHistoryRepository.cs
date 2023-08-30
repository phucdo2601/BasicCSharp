using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class SalaryHistoryRepository : RepositoryBase<SalaryHistory>, ISalaryHistoryRepository
    {
        private readonly SalaryConfirmContext _context;

        public SalaryHistoryRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
