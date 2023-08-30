

namespace LearnBasicGenericUnitOfWorkb01.Models.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public DateTime DateOfCreate { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; }
    }
}
