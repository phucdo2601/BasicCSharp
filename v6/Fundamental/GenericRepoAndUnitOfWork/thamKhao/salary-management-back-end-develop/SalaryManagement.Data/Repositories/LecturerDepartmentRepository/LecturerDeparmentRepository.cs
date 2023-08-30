using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class LecturerDepartmentRepository : RepositoryBase<LecturerDepartment>, ILecturerDepartmentRepository
    {
        private readonly SalaryConfirmContext _context;

        public LecturerDepartmentRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
