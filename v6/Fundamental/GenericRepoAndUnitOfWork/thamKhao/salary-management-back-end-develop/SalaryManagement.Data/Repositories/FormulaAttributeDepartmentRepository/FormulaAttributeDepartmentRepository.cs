using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FormulaAttributeDepartmentRepository : RepositoryBase<FormulaAttributeDepartment>, IFormulaAttributeDepartmentRepository
    {
        private readonly SalaryConfirmContext _context;

        public FormulaAttributeDepartmentRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
