using PracNet7ApiProB01.Dto.Dtos.StaffRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.StaffRoleService
{
    public interface IStaffRoleService : IGenericService<StaffRole>
    {
        #region Create new staff role
        Task<object> CreateNewStaffRole(CreateStaffRoleReqDto model);
        #endregion

        #region Update staff role
        Task<object> UpdateStaffRole(string staffRoleId, UpdateStaffRoleReqDto model);

        #endregion

        #region Delete Staff Role
        Task<object> DeleteStaffRole(string staffRoleId);
        #endregion




    }
}
