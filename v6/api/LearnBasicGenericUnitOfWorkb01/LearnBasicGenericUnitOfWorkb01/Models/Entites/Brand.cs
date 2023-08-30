

namespace LearnBasicGenericUnitOfWorkb01.Models.Entites
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set;}

        public DateTime RegisterDate { get; set; }

        public bool IsCooperation { get; set;}

        public List<Item> Items { get; set; }
    }
}
