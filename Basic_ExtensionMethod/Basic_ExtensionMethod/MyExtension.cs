using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ExtensionMethod
{
    public static class MyExtension
    {
        public static double BinhPhuong(this double x) => x * x;
        public static double CanBacHai(this double x) => Math.Sqrt(x);
    }
}
