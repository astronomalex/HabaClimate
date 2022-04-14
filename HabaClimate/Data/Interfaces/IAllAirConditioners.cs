using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HabaClimate.Data.Models;
using HabaClimate.DTOs;

namespace HabaClimate.Data.Interfaces
{
    public interface IAllAirConditioners
    {
        IEnumerable<AirConditioner> AirConditioners { get; }
        Task<IEnumerable<GoodDto>> AllGoodsAsync();
        Task<GoodDto> GetGoodAsync(int id);
        IEnumerable<AirConditioner> GetFavAirConditioners { get; }
        AirConditioner GetObjectAirConditioner(int goodId);
    }
}