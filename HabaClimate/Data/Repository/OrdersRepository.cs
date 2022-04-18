using System;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDbContext appDbContext, ShopCart shopCart)
        {
            _appDbContext = appDbContext;
            _shopCart = shopCart;
        }
        
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var items = _shopCart.CartItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GoodId = item.Good.Id,
                    OrderId = order.Id,
                    Price = item.Good.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}