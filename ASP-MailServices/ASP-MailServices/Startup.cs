using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_MailServices
{
    public class Startup
    {
        private readonly IConfiguration iconfiguration;

        public Startup(IConfiguration _confugration)
        {
            iconfiguration = _confugration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailSettings = iconfiguration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSettings);
            services.AddTransient<SendMailServices>();
        }

        /* Mail Server - Smtp
            SmtpClient -
            Server : Mail Transporter (CentOS / Qmail, SendMail)
         */

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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/sendmail", async context =>
                {
                    string kq = await MailUtils.MailUtils.SendMail("haivann2000@gmail.com", "haivann2000@gmail.com", "abc", "abc");
                    await context.Response.WriteAsync(kq);
                });
                endpoints.MapGet("/sendgmail", async context =>
                {
                    string kq = await MailUtils.MailUtils.SendGMail("hainvhe140732@fpt.edu.vn", "hainvhe140732@fpt.edu.vn", "SubjectTest", "Content Test", "hainvhe140732@fpt.edu.vn", "xxxx");
                    await context.Response.WriteAsync(kq);
                });
                endpoints.MapGet("/TestSendMailServices", async context =>
                {
                    var sendMailServices = context.RequestServices.GetService<SendMailServices>();
                    var mailcontent = new MailContent();
                    mailcontent.To = "haivann2000@gmail.com";
                    mailcontent.Subject = "Test";
                    mailcontent.Body = "I <3 You alot";
                    string nonf = await sendMailServices.SendMail(mailcontent);
                    await context.Response.WriteAsync(nonf);
                });
            });
        }
    }
}