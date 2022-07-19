using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using HabaClimate.DTOs;
using HabaClimate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class ShopCartController : BaseApiController
    {
        
        private readonly IAllAirConditioners _airConditionerRepository;
        private readonly ShopCart _shopCart;


        public ShopCartController(IAllAirConditioners airConditionerRepository, ShopCart shopCart)
        {
            _airConditionerRepository = airConditionerRepository;
            _shopCart = shopCart;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCardItems()
        {
            var items = _shopCart.GetCartItems();

            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddToCart([FromBody] int id)
        {
            var item = _airConditionerRepository.AirConditioners.FirstOrDefault(a => a.Id == id);
            
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            else
            {
                return BadRequest("Good is not exist");
            }
            
            return Ok(item.Id);
        }

        [HttpGet("cartid")]
        public async Task<ActionResult<string>> GetCardId()
        {
            return _shopCart.ShopCartId;
        }

        // public ViewResult Index()
        // {
        //     var items = _shopCart.GetCartItems();
        //     _shopCart.CartItems = items;
        //
        //     var shopCartViewModel = new ShopCartViewModel()
        //     {
        //         ShopCart = _shopCart
        //     };
        //     return View(shopCartViewModel);
        // }

        // public RedirectToActionResult AddToCart(int id)
        // {
        //     var item = _airConditionerRepository.AirConditioners.FirstOrDefault(a => a.Id == id);
        //
        //     if (item != null)
        //     {
        //         _shopCart.AddToCart(item);
        //     }
        //
        //     return RedirectToAction("Index");
        // }
    }
}