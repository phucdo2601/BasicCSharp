using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class TeachingSummaryDetailRepository : RepositoryBase<TeachingSummaryDetail>, ITeachingSummaryDetailRepository
    {
        private readonly SalaryConfirmContext _context;

        public TeachingSummaryDetailRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
