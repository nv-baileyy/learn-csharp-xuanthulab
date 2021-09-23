using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dependency_Injection
{
    public class ServicesDI
    {
        public static void Invert()
        {
            // ClassA
            // IClassB -> Class B, CLassB1, CLassB2
            // IClassC -> ClassC, CLassc1
            // dk service : <service name, type of service>
            var services = new ServiceCollection();
            services.AddSingleton<IClassC, ClassC>();

            //services.AddSingleton<IClassB, ClassB>();

            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassB, ClassB2>(
                (IServiceProvider provider) =>
                {
                    ClassB2 b2 = new ClassB2(
                        provider.GetService<IClassC>(),
                        "Thuc hien boi B2"
                    );
                    return b2;
                }
            );
            services.AddSingleton<IClassC, ClassC>();
            var provider = services.BuildServiceProvider();
            var sa = provider.GetService<ClassA>();
            sa.ActionA();
        }
    }
}