using BlogWebApi.Application.Repositories.BlogCategoryRepository;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.CommentEntityRepository;
using BlogWebApi.Application.Repositories.InteractionEntityRepository;
using BlogWebApi.Application.Repositories.InteractionTypeEntityRepository;
using BlogWebApi.Application.Repositories.LikeEntityRepository;
using BlogWebApi.Application.Repositories.RoleEntityRepository;
using BlogWebApi.Application.Repositories.ShareEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBlogCategoryRepository BlogCategoryRepository => new BlogCategoryRepository(_dbContext);
        public IBlogRepository BlogRepository => new BlogRepository(_dbContext);
        public ICommentRepository CommentRepository => new CommentRepository(_dbContext);
        public IInteractionTypeRepository InteractionTypeRepository => new InteractionTypeRepository(_dbContext);
        public IInteractionRepostiory InteractionRepostiory => new InteractionRepository(_dbContext);
        public ILikeRepository LikeRepository => new LikeRepository(_dbContext);
        public IRoleRepository RoleRepository => new RoleRepository(_dbContext);
        public IShareRepository ShareRepository => new ShareRepository(_dbContext);
        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
