using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        private readonly SalaryConfirmContext _context;

        public AdminRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
