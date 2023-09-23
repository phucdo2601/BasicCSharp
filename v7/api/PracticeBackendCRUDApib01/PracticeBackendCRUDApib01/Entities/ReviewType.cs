using System.ComponentModel.DataAnnotations;

namespace PracticeBackendCRUDApib01.Entities
{
    public class ReviewType
    {
        [Key]
        public Guid ReviewTypeId { get; set; }
        public string ReviewTypeName { get; set; }
        public string Description{ get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
