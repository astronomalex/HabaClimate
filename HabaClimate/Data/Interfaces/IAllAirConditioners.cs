using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.Interfaces
{
    public interface IAllAirConditioners
    {
        IEnumerable<AirConditioner> AirConditioners { get; }
        IEnumerable<AirConditioner> GetFavAirConditioners { get; }
        AirConditioner GetObjectAirConditioner(int goodId);
    }
}