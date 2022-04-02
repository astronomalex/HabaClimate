using System.Collections.Generic;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data.Repository
{
    public class CategoryRepository : IGoodsCategory
    {
        public readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.categories
            .Include(a => a.Goods);
    }
}