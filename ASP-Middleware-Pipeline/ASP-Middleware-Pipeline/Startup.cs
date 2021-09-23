using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Middleware_Pipeline
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // boi vi SecondMiddleware duoc khai bao, trien khai tu Interface (IMiddleware) > la mot dependency cua IMiddleware
            // -- Nen can phai duoc dang ki services 
            services.AddScoped<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            //app.UseMiddleware<FirstMiddleware>(); // Use middleware in normal way
            app.UseFirstMiddleware();  // Use Extension Method
            app.UseMiddleware<SecondMiddleware>();
            // Thong tin duoc dong goi thanh httpContext duoc gui toi bao gom ca request va response
            app.UseRouting(); // EndpointRoutingMiddleware
            app.UseEndpoints(
                (enpoint) =>
                { // E1
                    enpoint.MapGet("/about.html", async context =>
                    {
                        await context.Response.WriteAsync(" Trang Thong tin ");
                    }); // E2
                    enpoint.MapGet("/haingv134.html", async context =>
                    {
                        await context.Response.WriteAsync(" Nguyen Van Hai Dep Trai hihihi ");
                    });
                }
             );
            // Re nhanh pipeline
            app.Map("/admin", (app1) =>
            {
                app1.UseRouting();
                app1.UseEndpoints(
                    (endpoint) => {
                        // BE1
                        endpoint.MapGet("/user", async (context) => {
                            await context.Response.WriteAsync("\n Nguyen Van Hai USER");
                        });
                        // BE2
                        endpoint.MapGet("/crush", async (context) => {
                            await context.Response.WriteAsync("\n anonymous USER");
                        });
                    }
                );

                // terminate Middleware M2
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("\n Da re nhanh sang admin");
                });
            });
            // terminate Middleware M1
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello");
            });
            /*
                HttpContext folow
                Pipeline: - StaticFileMiddleware
                            -  FirstMiddleware
                                - SecondMiddleware 
                                    - EndpointRoutingMiddleware (E1, E2)
                                        - M1 
            */
        }
    }
}
