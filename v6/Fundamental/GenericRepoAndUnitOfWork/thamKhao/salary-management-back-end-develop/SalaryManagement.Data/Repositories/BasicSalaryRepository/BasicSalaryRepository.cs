using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class BasicSalaryRepository : RepositoryBase<BasicSalary>, IBasicSalaryRepository
    {
        private readonly SalaryConfirmContext _context;

        public BasicSalaryRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
