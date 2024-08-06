using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Dto.Dtos.StaffRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Utils.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.StaffRoleService
{
    public class StaffRoleService : GenericService<StaffRole>, IStaffRoleService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<StaffRole> _repository;

        public StaffRoleService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<StaffRole> _repository) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region Create new Staff 
        public async Task<object> CreateNewStaffRole(CreateStaffRoleReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // TODO: VALIDATE ALL FIELDS NECESSARY
                    var Id = Guid.NewGuid();

                    /**
                     * set up auto mapping from input to the entity
                     * from: CreateStaffRoleReqDto
                     * to: StaffRole
                     */
                    var _modelMapperConfig = ModelMapperConfig.IniializeAutoMapper();
                    var staffRole = _modelMapperConfig.Map<CreateStaffRoleReqDto, StaffRole>(model);
                    staffRole.Id = Id;

                    _unitOfWork.StaffRoleRepository.CreateNew(staffRole);
                    int created = _unitOfWork.Save();
                    transaction.Commit();

                    var staffRoleCreated = _repository.FindById(Id);
                    return await Task.FromResult(new CommonResponseDto<StaffRole>
                    {
                        Status = HttpStatusCode.Created.ToString(),
                        Message = $"Add staff role successfully!",
                        StatusCode = (int) HttpStatusCode.Created,
                        Data = staffRoleCreated,
                    });
                }
                catch (Exception)
                {
                    string methodName = GeneralConfigs.LogCurrentMethodName();
                    transaction.Rollback();
                    return await Task.FromResult(new CommonResponseDto<StaffRole>
                    {
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = $"Execute {methodName} unsuccessfully. Please try again!",
                        StatusCode = (int)HttpStatusCode.InternalServerError

                    });
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
        #endregion

        #region DeleteStaffRole
        public async Task<object> DeleteStaffRole(string staffRoleId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid StaffRoleUuid = Guid.Parse(staffRoleId);
                    var staffRole = _repository.FindById(StaffRoleUuid);
                    if (staffRole == null) {
                        return await Task.FromResult(new CommonResponseDto<StaffRole>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Staff Role does not existed",
                            StatusCode = (int) HttpStatusCode.BadRequest
                        });
                    }
                    else
                    {
                        _unitOfWork.StaffRoleRepository.Delete(staffRole);
                        int deleted = _unitOfWork.Save();
                        transaction.Commit();

                        return await Task.FromResult(new CommonResponseDto<StaffRole>
                        {
                            Status = HttpStatusCode.OK.ToString(),
                            Message = $"Product Brand deleted successfully!",
                            StatusCode = (int) HttpStatusCode.OK,
                        });
                    }

                }
                catch (Exception)
                {
                    string methodName = GeneralConfigs.LogCurrentMethodName();
                    transaction.Rollback();
                    return await Task.FromResult(new CommonResponseDto<StaffRole>
                    {
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = $"Execute {methodName} unsuccessfully. Please try again!",
                        StatusCode = (int)HttpStatusCode.InternalServerError

                    });
                }
                finally
                {
                    _context.Dispose();
                }
            }
            
        }
        #endregion

        #region UpdateStaffRole
        public async Task<object> UpdateStaffRole(string staffRoleId, UpdateStaffRoleReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid staffRoleUuid = Guid.Parse(staffRoleId);

                    if (!staffRoleUuid.Equals(model.Id))
                    {
                        return await Task.FromResult(new CommonResponseDto<StaffRole>
                        {
                            Status= HttpStatusCode.BadRequest.ToString(),
                            Message = $"Id in update model and id param does not match",
                            StatusCode= (int)HttpStatusCode.BadRequest
                        });
                    }

                    var staffRole = _unitOfWork.StaffRoleRepository.FindById02(p => p.Id == model.Id);

                    if (staffRole == null)
                    {
                        return await Task.FromResult(new CommonResponseDto<ProductBrand>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Staff Role does not existed",
                            StatusCode = (int)HttpStatusCode.BadRequest
                        });
                    }

                    // TODO: VALIDATE ALL FIELDS NECESSARY
                    /**
                     * set up auto mapping from input to the entity
                     * from: UpdateStaffRoleReqDto
                     * to: StaffRole
                     */
                    var _modelMapperConfig = ModelMapperConfig.IniializeAutoMapper();
                    var staffRoleUp = _modelMapperConfig.Map<UpdateStaffRoleReqDto, StaffRole>(model);

                    _unitOfWork.StaffRoleRepository.Update(staffRoleUp);
                    int updated = _unitOfWork.Save();
                    transaction.Commit();

                    var staffRoleUpdated = _repository.FindById(staffRoleUuid);
                    return await Task.FromResult(new CommonResponseDto<StaffRole> {
                        Status = HttpStatusCode.OK.ToString(),
                        Message = $"Product Brand deleted successfully!",
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = staffRoleUpdated
                    });
                }
                catch (Exception)
                {
                    string methodName = GeneralConfigs.LogCurrentMethodName();
                    transaction.Rollback();
                    return await Task.FromResult(new CommonResponseDto<StaffRole>
                    {
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = $"Execute {methodName} unsuccessfully. Please try again!",
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    });
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
        #endregion
    }
}
