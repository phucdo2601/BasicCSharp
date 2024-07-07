using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Repositories.CustomerRepository;
using PracNet7ApiProB01.Model.Repositories.GeneralRoleRepository;
using PracNet7ApiProB01.Model.Repositories.GeneralUserInfoRepository;
using PracNet7ApiProB01.Model.Repositories.ProductBrandRepository;
using PracNet7ApiProB01.Model.Repositories.ProductRepository;
using PracNet7ApiProB01.Model.Repositories.StaffRepository;
using PracNet7ApiProB01.Model.Repositories.StaffRoleRepository;
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

        public IGeneralUserInfoRepository GeneralUserInfoRepository => new GeneralUserInfoRepository(_context);

        public IProductBrandRepository ProductBrandRepository => new ProductBrandRepository(_context);

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public ICustomerRepository CustomerRepository => new CustomerRepository(_context);

        public IStaffRoleRepository StaffRoleRepository => new StaffRoleRepository(_context);

        public IStaffRepository StaffRepository => new StaffRepository(_context);

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
