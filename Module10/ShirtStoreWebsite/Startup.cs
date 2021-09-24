using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ShirtStoreWebsite.Data;

namespace ShirtStoreWebsite
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShirtContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ShirtContext shirtContext)
        {
            shirtContext.Database.EnsureDeleted();
            shirtContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "defaultRoute",
                    pattern: "{controller=Shirt}/{action=Index}/{id?}");
            });
        }
    }
}
