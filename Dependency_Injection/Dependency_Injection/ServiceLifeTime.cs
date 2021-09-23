using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class ServiceLifeTime
    {
        public static void Process()
        {
            var service = new ServiceCollection();
            // dang ki cac dich vu
            //IClassC -> CLassC, CLassC1

            // SIngleton
            //service.AddSingleton<IClassC,ClassC1>();
            //
            service.AddScoped<IClassC, ClassC1>();
            var provider = service.BuildServiceProvider();

            // in singleton, if provider dont ClassC Object, it'll create only one time
            for (int i = 0; i < 5; i++)
            {
                var classc = provider.GetService<IClassC>();
                Console.WriteLine(classc.GetHashCode());
            }
            using (var scope = provider.CreateScope())
            {
                var provider1 = scope.ServiceProvider;
                var classc = provider1.GetService<IClassC>();
                Console.WriteLine(classc.GetHashCode());
            }
        }
    }
}
