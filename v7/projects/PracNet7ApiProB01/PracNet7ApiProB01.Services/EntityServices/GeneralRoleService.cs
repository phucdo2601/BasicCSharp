using PracNet7ApiProB01.Dto.Dtos.GeneralRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices
{
    public class GeneralRoleService : GenericService<GeneralRole>, IGeneralRoleService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<GeneralRole> _repository;

        public GeneralRoleService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<GeneralRole> _repository) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region CreateNewGenRole
        /// <summary>
        /// CreateNewGenRole
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <author>Phucdn</author>
        public GeneralRole CreateNewGenRole(CreateGeneralRoleReqDro model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var genRoleCode = _unitOfWork.GeneralRoleRepository.FindByCondition(e => e.GenRoleCode.Equals(model.GenRoleCode)).FirstOrDefault();
                    if (genRoleCode != null)
                    {
                        throw new Exception($"General Code '{genRoleCode}' already existed");
                    }

                    var genRoleTitle = _unitOfWork.GeneralRoleRepository.FindByCondition(e => e.GenRoleTitle.Equals(model.GenRoleTitle)).FirstOrDefault();

                    if (genRoleTitle != null)
                    {
                        throw new Exception($"General Title '{genRoleTitle}' already existed");
                    }

                    var Id = Guid.NewGuid();

                    GeneralRole generalRole = new GeneralRole()
                    {
                        Id = Id,
                        GenRoleCode = model.GenRoleCode,
                        GenRoleTitle = model.GenRoleTitle,
                    };

                    _unitOfWork.GeneralRoleRepository.CreateNew(generalRole);
                    int created = _unitOfWork.Save();
                    transaction.Commit();

                    var genCodeCreated = _repository.FindById(Id);
                    return generalRole;

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _unitOfWork.Dispose(); }
            }
        }

        public int DeleteGenRole(string genRoleId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid genRoleUuid = Guid.Parse(genRoleId);
                    var genRole = _unitOfWork.GeneralRoleRepository.FindById(genRoleUuid);
                    if (genRole == null)
                    {
                        throw new Exception($"General Code does not existed");
                    }
                    else
                    {
                        _unitOfWork.GeneralRoleRepository.Delete(genRole);
                        int deleted = _unitOfWork.Save();
                        transaction.Commit();
                        return deleted;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }
        }
        #endregion

        /// <summary>
        /// UpdateGenRole
        /// </summary>
        /// <param name="genRoleId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <author>Phucdn</author>
        public GeneralRole UpdateGenRole(string genRoleId, UpdateGenRoleReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid genRoleUuid = Guid.Parse(genRoleId);

                    if (!genRoleUuid.Equals(model.Id))
                    {
                        throw new Exception($"Id in update model and id param does not match");
                    }

                    var genRole = _unitOfWork.GeneralRoleRepository.FindById(genRoleUuid);

                    if (genRole == null)
                    {
                        throw new Exception($"General Code does not existed");
                    } else
                    {
                        if (genRole.GenRoleCode.Equals(model.GenRoleCode) && genRole.GenRoleTitle.Equals(model.GenRoleTitle))
                        {
                            genRole.GenRoleTitle = model.GenRoleTitle;
                            genRole.GenRoleCode = model.GenRoleCode;
                        } else
                        {
                            var genRoleCode = _unitOfWork.GeneralRoleRepository.FindByCondition(e => e.GenRoleCode.Equals(model.GenRoleCode)).FirstOrDefault();
                            if (genRoleCode != null)
                            {
                                throw new Exception($"General Code '{genRoleCode.GenRoleCode}' already existed");
                            }

                            var genRoleTitle = _unitOfWork.GeneralRoleRepository.FindByCondition(e => e.GenRoleTitle.Equals(model.GenRoleTitle)).FirstOrDefault();

                            if (genRoleTitle != null)
                            {
                                throw new Exception($"General Title '{genRoleTitle.GenRoleTitle}' already existed");
                            }

                            genRole.GenRoleTitle = model.GenRoleTitle;
                            genRole.GenRoleCode = model.GenRoleCode;
                        }
                    }

                    

                    

                    _unitOfWork.GeneralRoleRepository.Update(genRole);
                    int updated = _unitOfWork.Save();
                    transaction.Commit();

                    var genCodeUpdated = _repository.FindById(genRoleUuid);
                    return genCodeUpdated;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _unitOfWork.Dispose(); }
            }
        }
    }
}
