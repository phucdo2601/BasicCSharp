using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.InteractionTypeEntityRepository
{
    public class InteractionTypeRepository : GenericRepository<InteractionTypeEntity>, IInteractionTypeRepository
    {
        public InteractionTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
