using System.Linq;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using HabaClimate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllAirConditioners _airConditionerRepository;
        private readonly ShopCart _shopCart;


        public ShopCartController(IAllAirConditioners airConditionerRepository, ShopCart shopCart)
        {
            _airConditionerRepository = airConditionerRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetCartItems();
            _shopCart.CartItems = items;

            var shopCartViewModel = new ShopCartViewModel()
            {
                ShopCart = _shopCart
            };
            return View(shopCartViewModel);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _airConditionerRepository.AirConditioners.FirstOrDefault(a => a.Id == id);

            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}