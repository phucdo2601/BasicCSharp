using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Repositories
{
    public class GeneralRoleRepository : GenericRepository<GeneralRole>, IGeneralRoleRepository
    {
        private readonly PracNet7ApiDbContext _context;
        public GeneralRoleRepository(PracNet7ApiDbContext _context) : base(_context)
        {
            this._context = _context;
        }
    }
}
