using System.Collections.Generic;
using System.Linq;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data.Repository
{
    public class AirConditionerRepository : IAllAirConditioners
    {
        public readonly AppDbContext _appDbContext;

        public AirConditionerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<AirConditioner> AirConditioners => _appDbContext.airConditioners
            .Include(a => a.Brand)
            .Include(a => a.Category);

        public IEnumerable<AirConditioner> GetFavAirConditioners => _appDbContext.airConditioners
            .Where(a => a.IsFavorite)
            .Include(a => a.Brand)
            .Include(a => a.Category);

        public AirConditioner GetObjectAirConditioner(int goodId) =>
            _appDbContext.airConditioners.FirstOrDefault(a => a.Id == goodId);
    }
}