using System;

namespace HabaClimate.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Good Good { get; set; }
        public Decimal Price { get; set; }
        
        public string ShopCartId { get; set; }
    }
}