using System.Collections.Generic;

namespace HabaClimate.Data.Models
{
    public class Brand
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDesc { set; get; }
        public string LongDesc { set; get; }
        public string Img { set; get; }
        public List<Good> Goods { get; set; }
    }
}