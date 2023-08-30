using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class PayPolicyRepository : RepositoryBase<PayPolicy>, IPayPolicyRepository
    {
        private readonly SalaryConfirmContext _context;

        public PayPolicyRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
