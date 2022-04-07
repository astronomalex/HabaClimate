using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HabaClimate.Data.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }
        public List<CartItem> CartItems { get; set; }
        
        public readonly AppDbContext _appDbContext;

        public ShopCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Good good)
        {
            _appDbContext.CartItems.Add(new CartItem
            {
                ShopCartId = ShopCartId,
                Good = good,
                Price = good.Price
            });

            _appDbContext.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return _appDbContext.CartItems.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Good).ToList();
        }
    }
}