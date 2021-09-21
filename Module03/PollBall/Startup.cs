
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PollBall
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Query.ContainsKey("favorite"))
                {
                    var selectedValue = context.Request.Query["favorite"].ToString();
                    await context.Response.WriteAsync($"Selected value is: {selectedValue}");
                } else
                {
                    await next.Invoke();
                }
            });
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This text was generated by the app.Run middleware. as a parameter");
            });
        }
    }
}
