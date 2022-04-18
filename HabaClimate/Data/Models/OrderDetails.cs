namespace HabaClimate.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public decimal Price { get; set; }
        public virtual Good Good { get; set; }
        public virtual Order Order { get; set; }
    }
}