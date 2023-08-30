using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private readonly SalaryConfirmContext _context;

        public DepartmentRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
