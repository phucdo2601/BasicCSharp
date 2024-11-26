using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Shares
{
    public class ShareService : GenericService<ShareEntity>, IShareService
    {
        public ShareService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<ShareEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
