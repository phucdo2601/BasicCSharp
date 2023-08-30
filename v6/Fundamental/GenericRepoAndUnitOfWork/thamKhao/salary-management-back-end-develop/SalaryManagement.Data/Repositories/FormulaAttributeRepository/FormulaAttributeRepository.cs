using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FormulaAttributeRepository : RepositoryBase<FormulaAttribute>, IFormulaAttributeRepository
    {
        private readonly SalaryConfirmContext _context;

        public FormulaAttributeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
