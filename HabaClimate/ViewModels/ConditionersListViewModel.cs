using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.ViewModels
{
    public class ConditionersListViewModel
    {
        public IEnumerable<AirConditioner> AllAirConditioners { get; set; }
        
        public string CurrCategory { get; set; }
    }
}