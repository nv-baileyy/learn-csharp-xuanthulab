using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Razor_Hello
{/*
    Razor page (.cshtml) = html + c#
    Engine Razor -> bien dich cshtml -> Response
    @page
    @variable, systax... @{}
    Tag Helper -> Generate HTML Code
    @addTagHelper -> add tag helper supported
    TagHelper: asp-page : only for all file in current directory
*/

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // default directory to store .cshtml file is "Pages"
            services.AddRazorPages().AddRazorPagesOptions((option) =>
            {
                // change default directory to store .cshtml
                option.RootDirectory = "/Pages";
                option.Conventions.AddPageRoute("/Firstpage", "trang1");
                option.Conventions.AddPageRoute("/SecondPages", "trang2");
                option.Conventions.AddPageRoute("/ThirdPages", "trang3");
            });
            // convert all URL to lower case
            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.LowercaseUrls = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();  // -> tra ve mot HttpResponse
                //FirstPage.cshtml URL=/Firstpage /SecondPages /ThirdPages
                // Dichvu/Dichvu1 /Dichvu2
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            app.UseStatusCodePages();
        }
    }
}