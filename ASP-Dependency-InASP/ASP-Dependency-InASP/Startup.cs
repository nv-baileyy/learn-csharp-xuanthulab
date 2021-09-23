using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ASP_Dependency_InASP
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        // automatic inject configuration into start up (json default file: appsettings.json)
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // use Options (data)
            services.AddOptions();
            // create IConfigurationSection
            var testOption = configuration.GetSection("TestOption");
            // add options to services
            services.Configure<TestOptions>(testOption);
            // add a service name "Product", then use this service to TestOptionMiddleware services
            services.AddSingleton<ProductName>();
            //
            services.AddTransient<TestOptionMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<TestOptionMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/ShowOptions", async context =>
                {
                    // var configuration = context.RequestServices.GetService<IConfiguration>();
                    // var section = configuration.GetSection("TestOption").Get<TestOptions>();
                    var section = context.RequestServices.GetService<IOptions<TestOptions>>().Value;
                    ///
                    /*
                    StringBuilder ss = new StringBuilder();
                    ss.Append("TestOption:\n");
                    ss.Append($"opt_key1: {section.opt_key1} \n");
                    ss.Append($"opt_key2.k1: {section.opt_key2.k1}");
                    ss.Append($"opt_key2.k2: {section.opt_key2.k2}"); */
                    //await context.Response.WriteAsync(ss.ToString());
                    await context.Response.WriteAsync("Di qua ShowOptions");
                });
            });
        }
    }
}