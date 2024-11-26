using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Likes
{
    public class LikeService : GenericService<LikeEntity>, ILikeService
    {
        public LikeService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<LikeEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
