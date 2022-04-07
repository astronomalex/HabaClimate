using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<AirConditioner> FavAC { get; set; }
    }
}