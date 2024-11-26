using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Users
{
    public class UserService : GenericService<UserEntity>, IUserService
    {
        public UserService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<UserEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
