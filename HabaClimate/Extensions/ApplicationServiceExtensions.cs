using HabaClimate.Data;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.mocks;
using HabaClimate.Data.Models;
using HabaClimate.Data.Repository;
using HabaClimate.Helpers;
using HabaClimate.Interfaces;
using HabaClimate.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HabaClimate.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("developConnection")));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddCors();
            services.AddScoped<IAllAirConditioners, AirConditionerRepository>();
            services.AddScoped<IBrands, BrandRepository>();
            services.AddScoped<IAllOrders, OrdersRepository>();
            services.AddScoped<IGoodsCategory, CategoryRepository>();
            services.AddScoped(ShopCart.GetCart);

            return services;
        }    
    }
}