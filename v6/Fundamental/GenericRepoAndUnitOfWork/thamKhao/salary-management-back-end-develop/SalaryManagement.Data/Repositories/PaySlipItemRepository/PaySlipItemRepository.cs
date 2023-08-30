using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class PaySlipItemRepository : RepositoryBase<PaySlipItem>, IPaySlipItemRepository
    {
        private readonly SalaryConfirmContext _context;

        public PaySlipItemRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
