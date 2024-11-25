using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos.Comments
{
    public class CommentDto : BaseDto
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
    }
}
