using ButterfliesShop.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ButterfliesShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "ButterflyRoute",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Butterfly", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
