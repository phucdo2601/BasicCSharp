using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.BlogRepository
{
    public class BlogRepository : GenericRepository<BlogEntity>, IBlogRepository
    {
        public BlogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
