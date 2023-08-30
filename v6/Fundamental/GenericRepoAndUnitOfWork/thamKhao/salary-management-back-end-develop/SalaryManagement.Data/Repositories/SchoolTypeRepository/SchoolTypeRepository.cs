using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class SchoolTypeRepository : RepositoryBase<SchoolType>, ISchoolTypeRepository
    {
        private readonly SalaryConfirmContext _context;

        public SchoolTypeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
