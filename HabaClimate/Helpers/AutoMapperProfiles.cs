using AutoMapper;
using HabaClimate.Data.Models;
using HabaClimate.DTOs;

namespace HabaClimate.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Good, GoodDto>().AfterMap((g, d) =>
            {
                d.CategoryName = g.Category.CategoryName;
                d.BrandName = g.Brand.Name;
            });
            CreateMap<GoodDto, Good>();
            CreateMap<AirConditioner, GoodDto>();
            CreateMap<GoodDto, AirConditioner>();
            
            CreateMap<RegisterDto, AppUser>();
            
        }
    }
}