using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class SemesterRepository : RepositoryBase<Semester>, ISemesterRepository
    {
        private readonly SalaryConfirmContext _context;

        public SemesterRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
