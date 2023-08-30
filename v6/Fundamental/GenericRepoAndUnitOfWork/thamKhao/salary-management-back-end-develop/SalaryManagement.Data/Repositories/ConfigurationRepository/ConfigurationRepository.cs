using SalaryManagement.Infrastructure;
using SalaryManagement.Models;

namespace SalaryManagement.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>, IConfigurationRepository
    {
        private readonly SalaryConfirmContext _context;

        public ConfigurationRepository(SalaryConfirmContext context) : base(context)
        {
            _context = context;
        }
    }
}
