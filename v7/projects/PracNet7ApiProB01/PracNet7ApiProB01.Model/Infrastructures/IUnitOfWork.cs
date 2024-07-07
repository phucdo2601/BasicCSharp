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
    public interface IUnitOfWork : IDisposable
    {
        IGeneralRoleRepository GeneralRoleRepository { get; }
        IGeneralUserInfoRepository GeneralUserInfoRepository { get; }
        IProductBrandRepository ProductBrandRepository { get; }
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IStaffRoleRepository StaffRoleRepository { get; }
        IStaffRepository StaffRepository { get; }

        int Save();
    }
}
