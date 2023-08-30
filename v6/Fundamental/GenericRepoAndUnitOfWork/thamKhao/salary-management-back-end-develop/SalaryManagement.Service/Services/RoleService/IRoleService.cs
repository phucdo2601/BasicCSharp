using SalaryManagement.Models;
using System.Collections.Generic;

namespace SalaryManagement.Services.RoleService
{
    public interface IRoleService
    {
        List<Role> GetRoles();
    }
}
