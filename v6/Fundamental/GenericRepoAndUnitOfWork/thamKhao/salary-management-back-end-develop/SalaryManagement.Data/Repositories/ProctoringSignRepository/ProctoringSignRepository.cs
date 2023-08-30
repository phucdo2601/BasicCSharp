using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class ProctoringSignRepository : RepositoryBase<ProctoringSign>, IProctoringSignRepository
    {
        private readonly SalaryConfirmContext _context;

        public ProctoringSignRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
