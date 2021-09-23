
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ZooSite.Data;
using ZooSite.Middleware;

namespace ZooSite
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
            services.AddDbContext<ZooContext>(options =>
                  options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ZooContext zooContext)
        {
            zooContext.Database.EnsureDeleted();
            zooContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseRouting();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "ZooRoute",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Zoo", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
