using LearnBasicGenericUnitOfWorkb01.Models.Entites;

namespace LearnBasicGenericUnitOfWorkb01.Dtos.Request
{
    public class CategoryRequestModel
    {
        public string CategoryName { get; set; }

        public DateTime DateOfCreate { get; set; }

        public string Description { get; set; }
    }
}
