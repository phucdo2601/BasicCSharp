using PracNet7ApiProB01.Dto.Dtos.GeneralRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.GeneralRoleService
{
    public interface IGeneralRoleService : IGenericService<GeneralRole>
    {

        #region CreateNewGenRole
        Task<object> CreateNewGenRole(CreateGeneralRoleReqDro model);
        #endregion

        #region UpdateGenRole
        Task<object> UpdateGenRole(string genRoleId, UpdateGenRoleReqDto model);

        #endregion

        #region Delete Gen Role
        Task<object> DeleteGenRole(string genRoleId);

        #endregion
    }
}
