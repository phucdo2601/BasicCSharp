using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos.Blogs
{
    public class BlogUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public Guid BlogCategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
