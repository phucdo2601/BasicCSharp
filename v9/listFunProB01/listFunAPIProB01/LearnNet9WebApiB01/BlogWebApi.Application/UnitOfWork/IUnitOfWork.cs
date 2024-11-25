using BlogWebApi.Application.Repositories.BlogCategoryRepository;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.CommentEntityRepository;
using BlogWebApi.Application.Repositories.InteractionEntityRepository;
using BlogWebApi.Application.Repositories.InteractionTypeEntityRepository;
using BlogWebApi.Application.Repositories.LikeEntityRepository;
using BlogWebApi.Application.Repositories.RoleEntityRepository;
using BlogWebApi.Application.Repositories.ShareEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogCategoryRepository BlogCategoryRepository { get; }

        IBlogRepository BlogRepository { get; }

        ICommentRepository CommentRepository { get; }

        IInteractionRepostiory InteractionRepostiory { get; }

        IInteractionTypeRepository InteractionTypeRepository { get; }

        ILikeRepository LikeRepository { get; }

        IRoleRepository RoleRepository { get; }

        IShareRepository ShareRepository { get; }

        IUserRepository UserRepository { get; }

        int save();
    }
}
