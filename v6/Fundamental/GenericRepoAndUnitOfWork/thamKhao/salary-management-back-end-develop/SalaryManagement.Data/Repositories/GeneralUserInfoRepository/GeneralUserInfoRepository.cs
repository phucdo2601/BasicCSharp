using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class GeneralUserInfoRepository : RepositoryBase<GeneralUserInfo>, IGeneralUserInfoRepository
    {
        private readonly SalaryConfirmContext _context;

        public GeneralUserInfoRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
