namespace HabaClimate.DTOs
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public decimal Price { get; set; }
    }
}