using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos.InteractionTypes
{
    public class UpdateInteractionTypeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}