using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FormulaAttributeFormulaRepository : RepositoryBase<FormulaAttributeFormula>, IFormulaAttributeFormulaRepository
    {
        private readonly SalaryConfirmContext _context;

        public FormulaAttributeFormulaRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
