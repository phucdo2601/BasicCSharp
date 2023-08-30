using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly SalaryConfirmContext _context;

        public RoleRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
