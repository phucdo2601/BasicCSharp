using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Role> GetRoles()
        {
            var RoleList = _unitOfWork.Role.FindAll().ToList();
            return RoleList;
        }
    }
}
