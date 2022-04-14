using HabaClimate.Data;
using HabaClimate.Data.Interfaces;
using HabaClimate.Data.mocks;
using HabaClimate.Data.Models;
using HabaClimate.Data.Repository;
using HabaClimate.Extensions;
using HabaClimate.Helpers;
using HabaClimate.Interfaces;
using HabaClimate.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HabaClimate
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private IConfigurationRoot _configurationRoot;

        public Startup(IHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.Development.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });
            
            services.AddIdentityServices(_configurationRoot);
            services.AddApplicationServices(_configurationRoot);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            
            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("categoryfilter", "AirConditioners/{action}/{category?}",
                    new { controller = "Conditioner", action = "List"});
            });
            
            
            AppDbContext context;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initial(context);
            }
        }
    }
}