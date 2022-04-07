using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.mocks;
using HabaClimate.Data.Models;
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

        [Route("Conditioner/List")]
        [Route("Conditioner/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<AirConditioner> airConditioners = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(_category))
            {
                airConditioners = _airConditioners.AirConditioners.OrderBy(a => a.Id);
            } else if (string.Equals("split", category, StringComparison.OrdinalIgnoreCase))
            {
                airConditioners = _airConditioners.AirConditioners
                    .Where(a => a.Category.CategoryName == "Сплит системы");
                currCategory = "Сплит системы";
            }
            else if (string.Equals("mobile", category, StringComparison.OrdinalIgnoreCase))
            {
                airConditioners = _airConditioners.AirConditioners
                    .Where(a => a.Category.CategoryName == "Мобильные системы кондиционирвания");
                currCategory = "Мобильные системы кондиционирвания";
            }

            var acObj = new ConditionersListViewModel()
            {
                AllAirConditioners = airConditioners,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Страница с кондиционерами";
            
            return View(acObj);
        }
    }
}