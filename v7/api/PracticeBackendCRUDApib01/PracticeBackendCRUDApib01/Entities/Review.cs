using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public Guid ContentReviewId { get; set; }
        public string ContentReviewBody { get; set; }
        public string ContentReviewTitle { get; set;}
        public DateTime CreatedAt { get; set; }

        public Guid ReviewTypeId { get; set; }

        [ForeignKey("ReviewTypeId")]
        public ReviewType ReviewType { get; set; }
    }
}
