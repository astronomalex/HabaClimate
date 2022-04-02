using System.Collections;
using System.Collections.Generic;
using HabaClimate.Data.Models;

namespace HabaClimate.Data.Interfaces
{
    public interface IGoodsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}