using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Repositories.InteractionEntityRepository
{
    public class InteractionRepository : GenericRepository<InteractionEntity>, IInteractionRepostiory
    {
        public InteractionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
