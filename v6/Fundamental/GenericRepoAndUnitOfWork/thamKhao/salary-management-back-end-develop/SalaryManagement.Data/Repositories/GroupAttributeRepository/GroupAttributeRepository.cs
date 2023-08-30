using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class GroupAttributeRepository : RepositoryBase<GroupAttribute>, IGroupAttributeRepository
    {
        private readonly SalaryConfirmContext _context;

        public GroupAttributeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
