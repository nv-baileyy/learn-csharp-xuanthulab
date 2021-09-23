using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Hello_ASP
{
    /*
Host(IHost) object:
- Dependency Injection (DI): IserviceProvider (ServiceCollection)
- Logging (ILoggin)
- Congiguration
- IHostedService => StartAsync : run HTTP Server (default) (Kestrel Http)
1) IHostBuilder
2) Cau hinh, dang ky cac dich du -> goi ConfigureWebHostDefaults
3) IHostBuilder.Build() => Host(IHost)
4) Host.Run() => StartAsync()

<.> cau hinh khi nhan request, thi doan code nao xu ly cac doan code do
Request => pipeline (Middleware)
*/

    public class Program
    {
        // public static void Main(string[] args){
        //     Console.WriteLine("Starting up...!!!");
        //     IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //     // default comfiguration for this Host
        //     builder.ConfigureWebHostDefaults(
        //         (IWebHostBuilder webBuilder) => {
        //             // tuy bien them ve host
        //             // pipeline
        //             webBuilder.UseStartup<MyStartup>();
        //             webBuilder.UseWebRoot("publicDirectory");
        //         }
        //     );
        //     IHost host = builder.Build();
        //     host.Run();

        // }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<MyStartup>();
                });
    }
}