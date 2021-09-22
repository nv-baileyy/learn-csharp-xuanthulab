using System;

namespace Basic_Null_Nullable
{
    class Program
    {
        class Abc
        {
            public void Xinchao() => Console.WriteLine("hello world");
        }
        static void Main(string[] args)
        {
            Abc abc = new Abc();
            abc?.Xinchao(); // = if (a!=null) a.xinchao()
            int? x; // allow x accept null value
            x = null;
            x = 10;            
            if (x.HasValue)
            {
                Console.WriteLine($"x has value: {x}");
            }
        }
    }
}
