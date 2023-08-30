using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FormulaAttributeTypeRepository : RepositoryBase<FormulaAttributeType>, IFormulaAttributeTypeRepository
    {
        private readonly SalaryConfirmContext _context;

        public FormulaAttributeTypeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
