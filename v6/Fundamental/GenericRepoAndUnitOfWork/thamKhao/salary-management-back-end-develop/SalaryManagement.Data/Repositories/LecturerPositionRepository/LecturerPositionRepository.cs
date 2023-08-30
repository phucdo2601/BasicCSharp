using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class LecturerPositionRepository : RepositoryBase<LecturerPosition>, ILecturerPositionRepository
    {
        private readonly SalaryConfirmContext _context;

        public LecturerPositionRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
