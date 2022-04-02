using System.Collections.Generic;

namespace HabaClimate.Data.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }
        public List<Good> Goods { set; get; }
    }
}