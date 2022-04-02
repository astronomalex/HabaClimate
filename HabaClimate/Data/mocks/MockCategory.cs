using System.Collections.Generic;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.mocks
{
    public class MockCategory : IGoodsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Сплит системы", Desc = "Системы кондиционирования воздуха" },
                    new Category
                        { CategoryName = "Мобильные кондиционеры", Desc = "Мобильные системы кондиционирвания" }
                };
            }
        }
    }
}