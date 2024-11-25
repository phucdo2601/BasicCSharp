using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.BlogCategories
{
    public class BlogCategoryService : GenericService<BlogCategoryEntity>, IBlogCategoryService
    {
        public BlogCategoryService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<BlogCategoryEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
