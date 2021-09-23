using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Session
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDistributedMemoryCache(); // save session in server memory
            // save session in sql server cache
            services.AddDistributedSqlServerCache(
                (option) => {
                    option.ConnectionString = "Data Source=DESKTOP-TMG5088;Initial Catalog=webdb;Integrated Security=True";
                    option.SchemaName = "dbo";
                    option.TableName = "Session";
                }
            );
            services.AddSession(
                (SessionOptions options) => {
                    options.Cookie.Name = "haingv134";
                    options.IdleTimeout = new TimeSpan(0, 30, 0);
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // khi httpContext di qua SessionMiddleware, thi du lieu phien lafm viec se duoc giu lai trong 1 thuoc tinh la Session
            app.UseSession(); // SessionMiddleware -> Cookie
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null)
                    {
                        count = 0;
                    }
                    count++;
                    context.Session.SetInt32("count", count.Value);

                    await context.Response.WriteAsync($"So lan truy cap: {count}\n");
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/readwritesession", async context =>
                {
                    int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null)
                    {
                        count = 0;
                    }
                    count++;
                    context.Session.SetInt32("count", count.Value);

                    await context.Response.WriteAsync($"So lan truy cap: {count}");
                });
            });
        }
    }
}
