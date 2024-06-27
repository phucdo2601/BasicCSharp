using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PracNet7ApiDbContext _context;

        public UnitOfWork(PracNet7ApiDbContext _context)
        {
            this._context = _context;
        }

        public IGeneralRoleRepository GeneralRoleRepository => new GeneralRoleRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            int result = _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return result;
        }
    }
}
