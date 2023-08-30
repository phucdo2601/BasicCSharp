using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        private readonly SalaryConfirmContext _context;

        public SchoolRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
