using HabaClimate.Data.Interfaces;
using HabaClimate.Data.mocks;
using HabaClimate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HabaClimate.Controllers
{
    public class ConditionerController : Controller
    {
        private readonly IBrands _brands;
        private readonly IAllAirConditioners _airConditioners;
        private readonly IGoodsCategory _categories;

        public ConditionerController(IAllAirConditioners conditioners,
            IBrands brands, IGoodsCategory goodsCategory)
        {
            _brands = brands;
            _categories = goodsCategory;
            _airConditioners = conditioners;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с кондиционерами";
            ConditionersListViewModel viewModel = new ConditionersListViewModel();
            viewModel.AllAirConditioners = _airConditioners.AirConditioners;
            viewModel.CurrCategory = "Кондиционеры";
            return View(viewModel);
        }
    }
}