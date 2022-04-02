using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.mocks
{
    public interface IBrands
    {
        IEnumerable<Brand> AllBrands { get; }
    }
}