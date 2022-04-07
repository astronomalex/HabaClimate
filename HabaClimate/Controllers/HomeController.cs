using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using HabaClimate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllAirConditioners _airConditionerRepository;
        private readonly ShopCart _shopCart;


        public HomeController(IAllAirConditioners airConditionerRepository, ShopCart shopCart)
        {
            _airConditionerRepository = airConditionerRepository;
            _shopCart = shopCart;
        }

        // GET
        public ViewResult Index()
        {
            var homeACs = new HomeViewModel()
            {
                FavAC = _airConditionerRepository.GetFavAirConditioners
            };
            return View(homeACs);
        }
    }
}