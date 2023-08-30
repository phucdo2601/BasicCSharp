using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class PayPeriodRepository : RepositoryBase<PayPeriod>, IPayPeriodRepository
    {
        private readonly SalaryConfirmContext _context;

        public PayPeriodRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
