using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Roles
{
    public class RoleService : GenericService<RoleEntity>, IRoleService
    {
        public RoleService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<RoleEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
