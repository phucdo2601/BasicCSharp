using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class TeachingSummaryRepository : RepositoryBase<TeachingSummary>, ITeachingSummaryRepository
    {
        private readonly SalaryConfirmContext _context;

        public TeachingSummaryRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
