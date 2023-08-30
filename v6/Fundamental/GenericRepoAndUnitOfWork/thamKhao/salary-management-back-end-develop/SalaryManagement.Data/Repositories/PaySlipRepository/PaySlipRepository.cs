using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class PaySlipRepository : RepositoryBase<PaySlip>, IPaySlipRepository
    {
        private readonly SalaryConfirmContext _context;

        public PaySlipRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
