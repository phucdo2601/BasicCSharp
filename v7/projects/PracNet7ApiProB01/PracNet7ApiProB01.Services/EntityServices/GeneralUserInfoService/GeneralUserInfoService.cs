using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.GeneralUserInfoService
{
    public class GeneralUserInfoService : GenericService<GeneralUserInfo>, IGeneralUserInfoService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public GeneralUserInfoService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<GeneralUserInfo> _repository) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
        }


    }
}
