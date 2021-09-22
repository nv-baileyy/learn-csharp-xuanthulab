using System;

namespace Basic_PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            int? maybe = 12;

            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
        }
    }
}
