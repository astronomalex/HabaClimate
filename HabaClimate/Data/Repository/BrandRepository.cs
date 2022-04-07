using System.Collections.Generic;
using System.Linq;
using HabaClimate.Data.mocks;
using HabaClimate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data.Repository
{
    public class BrandRepository : IBrands
    {
        public readonly AppDbContext _appDbContext;

        public BrandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Brand> AllBrands => _appDbContext.Brands
            .Include(a => a.Goods);
    }
}