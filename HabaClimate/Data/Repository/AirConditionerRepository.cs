using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.Models;
using HabaClimate.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data.Repository
{
    public class AirConditionerRepository : IAllAirConditioners
    {
        public readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AirConditionerRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public IEnumerable<AirConditioner> AirConditioners => _appDbContext.AirConditioners
            .Include(a => a.Brand)
            .Include(a => a.Category);

        public async Task<IEnumerable<GoodDto>> AllGoodsAsync()
        {
            var goods = await _appDbContext.AirConditioners.ToListAsync();
            var dtos = new List<GoodDto>();

            foreach (var good in goods)
            {
                dtos.Add(_mapper.Map<GoodDto>(good));
            }
            
            return dtos;
        }

        public async Task<GoodDto> GetGoodAsync(int id)
        {
            var good = _appDbContext.AirConditioners.FirstOrDefault(g => g.Id == id);
            return _mapper.Map<GoodDto>(good);
        }

        public IEnumerable<AirConditioner> GetFavAirConditioners => _appDbContext.AirConditioners
            .Where(a => a.IsFavorite)
            .Include(a => a.Brand)
            .Include(a => a.Category);

        public AirConditioner GetObjectAirConditioner(int goodId) =>
            _appDbContext.AirConditioners.FirstOrDefault(a => a.Id == goodId);
    }
}