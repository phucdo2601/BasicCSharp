using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class LecturerTypeRepository : RepositoryBase<LecturerType>, ILecturerTypeRepository
    {
        private readonly SalaryConfirmContext _context;

        public LecturerTypeRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
