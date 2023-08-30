using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class SemesterSchoolTypeRepository : RepositoryBase<SemesterSchoolType>, ISemesterSchoolTypeRepository
    {
        private readonly SalaryConfirmContext _context;

        public SemesterSchoolTypeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
