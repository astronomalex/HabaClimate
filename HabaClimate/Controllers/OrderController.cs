using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.CartItems = _shopCart.GetCartItems();

            if (_shopCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "В корзине должны быть добавлены товары!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успушно обработан";
            return View();
        }
    }
}