using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class FESalaryRepository : RepositoryBase<Fesalary>, IFESalaryRepository
    {
        private readonly SalaryConfirmContext _context;

        public FESalaryRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
