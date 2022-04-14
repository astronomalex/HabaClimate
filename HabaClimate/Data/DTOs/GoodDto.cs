namespace HabaClimate.DTOs
{
    public class GoodDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public decimal Price { set; get; }
        public bool Available { set; get; }
        public bool IsFavorite { get; set; }
        
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        
        public string BrandName { get; set; }
    }
}