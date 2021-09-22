using System;

// extension method
// lop tinh static
namespace Basic_ExtensionMethod
{
    // mo rong them method Print cho String : this string
    internal static class Ab
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = "xin chao cac ban";
            s.Print(ConsoleColor.Green);
            s.Print(ConsoleColor.Red);
            "Xin".Print(ConsoleColor.Gray);

            double a = 2.5;
            Console.WriteLine($"binh phuongL {a.BinhPhuong()}, can bac hai: {a.CanBacHai()}");
        }
    }
}