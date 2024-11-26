using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Blogs
{
    public class BlogService : GenericService<BlogEntity>, IBlogService
    {
        public BlogService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<BlogEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
