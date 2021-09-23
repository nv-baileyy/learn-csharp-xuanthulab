using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hello_ASP
{
    public class MyStartup
    {
        // min: two methods
        // dang ky cac service ung dung (DI)
        public void ConfigureServices(IServiceCollection service)
        {
            // service.AddSingleton()
        }

        // xay dung pipeline (chuoi middware) -> response
        // pipeline: chuoi nhung doan code ma message cua HttpRequestMessage phai di qua va tra ve HttpResponseMessage
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Request luon luon di qua EndpointRoutingMiddleware
            app.UseRouting();  // EndpointRoutingMiddleware
            app.UseEndpoints(endpoints =>
            {
                //StaticFileMiddleware
                app.UseStaticFiles();

                // GET /
                endpoints.MapGet("/", async (context) =>
                {
                    await context.Response.WriteAsync("Trang chu");
                });
                endpoints.MapGet("/about", async (context) =>
                {
                    await context.Response.WriteAsync("Trang gioi thieu");
                });
                endpoints.MapGet("/contact", async (context) =>
                {
                    await context.Response.WriteAsync("Trang lien he");
                });
                // POST /
                // endpoints.MapPost("/", async (context) => {
                //     await context.Request.
                // });
            }
            );
            // endpoint
            // Terminate Middleware M2
            // using Microsoft.Extensions.Hosting;
            app.Map("/abc", app1 =>
            {
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Noi dung tra ve tu abc");
                });
            });
            // Terminate Middleware M1
            // app.Run(async (HttpContext context) =>
            // {
            //     await context.Response.WriteAsync("Xin chao day la MyStartup");
            // });
            //------------------------------
            // StatusCodePages middleware -- error handler
            // put end point
            // neu tat ca cac middleware khac khong xu ly dc cac yeu cau request
            app.UseStatusCodePages();
        }
    }
}