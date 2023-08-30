using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FormulaRepository : RepositoryBase<Formula>, IFormulaRepository
    {
        private readonly SalaryConfirmContext _context;

        public FormulaRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
