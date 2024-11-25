using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos.Interactions
{
    public class CreateInteractionDto
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public Guid InteractionTypeId { get; set; }
    }
}
