using System.ComponentModel.DataAnnotations;

namespace Les03FunRazorPage.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(0, 10000000, ErrorMessage = "Display order must be in range of 1-1000000")]
        public int DisplayOrder { get; set; }

    }
}
