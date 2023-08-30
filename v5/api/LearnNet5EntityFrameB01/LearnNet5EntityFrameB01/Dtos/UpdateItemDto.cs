namespace LearnNet5EntityFrameB01.Dtos
{
    public class UpdateItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int? CategoryId { get; set; }
    }
}
