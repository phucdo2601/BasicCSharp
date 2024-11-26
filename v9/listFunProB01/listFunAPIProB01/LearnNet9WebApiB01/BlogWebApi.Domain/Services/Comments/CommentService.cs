using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Comments
{
    public class CommentService : GenericService<CommentEntity>, ICommentService
    {
        public CommentService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<CommentEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
