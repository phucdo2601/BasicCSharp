using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.InteractionTypes
{
    public class InteractionTypeService : GenericService<InteractionEntity>, IInteractionTypeService
    {
        public InteractionTypeService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<InteractionEntity> repository) : base(context, unitOfWork, repository)
        {
        }
    }
}
