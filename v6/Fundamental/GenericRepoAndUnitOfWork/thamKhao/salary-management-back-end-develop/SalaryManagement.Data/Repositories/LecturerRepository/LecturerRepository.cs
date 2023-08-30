using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class LecturerRepository : RepositoryBase<Lecturer>, ILecturerRepository
    {
        private readonly SalaryConfirmContext _context;

        public LecturerRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
