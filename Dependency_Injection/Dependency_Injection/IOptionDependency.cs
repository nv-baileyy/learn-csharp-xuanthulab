using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Dependency_Injection
{
    public class MyServicesOptions
    {
        public string data1 { get; set; }
        public string data2 { get; set; }
    }

    public class MyService
    {
        public string data1 { get; set; }
        public string data2 { get; set; }

        public MyService(IOptions<MyServicesOptions> _options)
        {
            var value = _options.Value;
            data1 = value.data1;
            data2 = value.data2;
        }

        public void PrintInfor() => Console.WriteLine($"Data1: {data1}, data2: {data2}");
    }

    public class IOptionDependency
    {
        // use custome json file (default: appsetting.json)
        public static IConfigurationSection FromFile()
        {
            // du lieu cau hinh cua ung dung
            IConfigurationRoot configurationRoot;
            // nap cau hinh tu cac file
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            // set current folder
            
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("cauhinh.json");

            configurationRoot = configBuilder.Build();
            //var key1 = configurationRoot.GetSection("MyServiceOptions").GetSection("data1");
            IConfigurationSection section = configurationRoot.GetSection("MyServiceOptions");
            return section;
        }

        public static void Process()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MyService>();

            // using deligate to add data to Options
            //
            // services.Configure<MyServicesOptions>(
            //     (MyServicesOptions ms) => {
            //         ms.data1 = "du lieu 1";
            //         ms.data2 = "du lieu 2";
            //     }
            // );
            // -------------------------------
            // using file to import file to Options
            services.Configure<MyServicesOptions>(FromFile());
            var provider = services.BuildServiceProvider();
            MyService myService = provider.GetService<MyService>();
            myService.PrintInfor();
        }
    }
}