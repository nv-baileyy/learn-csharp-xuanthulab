using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASP_HttpRequest_Json_Cookie
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("This is root directory");
                });
                endpoints.MapGet("/RequestInfor", async context =>
                {
                    await context.Response.WriteAsync("RequestInfor\n");
                    await context.Response.WriteAsync(RequestProcess.RequestInformation(context.Request));
                });
                endpoints.MapGet("/Encoding", async context =>
                {
                    await context.Response.WriteAsync("Encoding");
                });
                endpoints.MapGet("/Cookies/{*action}", async context =>
                {
                    var action = context.Request.RouteValues["action"] ?? "read";  // if null, return read string
                    if (action.ToString().Equals("write"))
                    {
                        var options = new CookieOptions()
                        {
                            Path = "/",
                            Expires = DateTime.Now.AddDays(1)
                        };
                        context.Response.Cookies.Append("who", "Hai Nguye", options);
                        context.Response.Cookies.Append("where", "Bac Giang", options);
                        await context.Response.WriteAsync("Cookies write OK");
                    }
                    else if (action.ToString().Equals("read"))
                    {
                        StringBuilder ss = new StringBuilder();
                        context.Request.Cookies.ToList().ForEach(
                            keypar => ss.Append(keypar.Key + " : " + keypar.Value + " \n")
                        );
                        await context.Response.WriteAsync("Cookies\n" + ss.ToString());
                    }

                });
                endpoints.MapGet("/Json", async context =>
                {
                    var p = new
                    {
                        Ten = "Hai NGuyen",
                        Gia = "Unlinited",
                        NgaySX = "13-04-2000"
                    };
                    string strJson = JsonSerializer.Serialize(p);
                    await context.Response.WriteAsync(strJson);

                });
                endpoints.MapMethods("/Form", new string[] { "GET", "POST" }, async context =>
                {
                    await context.Response.WriteAsync(RequestProcess.FormProcess(context.Request));
                });
                // endpoints.MapPost("/Form", async context =>
                // {

                //     await context.Response.WriteAsync("Form");
                // });
            });
        }
    }
}
