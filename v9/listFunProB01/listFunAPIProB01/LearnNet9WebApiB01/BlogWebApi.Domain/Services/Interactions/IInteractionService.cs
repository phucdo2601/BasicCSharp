using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Interactions
{
    public interface IInteractionService : IGenericService<InteractionEntity>
    {
    }
}
