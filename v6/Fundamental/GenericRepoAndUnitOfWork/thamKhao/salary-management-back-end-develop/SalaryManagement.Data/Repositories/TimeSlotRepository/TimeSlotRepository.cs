using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class TimeSlotRepository : RepositoryBase<TimeSlot>, ITimeSlotRepository
    {
        private readonly SalaryConfirmContext _context;

        public TimeSlotRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
