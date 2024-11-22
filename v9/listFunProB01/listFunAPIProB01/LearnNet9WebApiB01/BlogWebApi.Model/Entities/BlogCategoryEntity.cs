using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "blog_cates_tbl")]
    public class BlogCategoryEntity : BaseEntity
    {
        public string BlogCategoryTitle { get; set; }
        public ICollection<BlogEntity> BlogEntities { get; set; }
    }
}
