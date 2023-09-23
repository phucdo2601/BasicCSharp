using System.ComponentModel.DataAnnotations;

namespace PracticeBackendCRUDApib01.Entities
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}
