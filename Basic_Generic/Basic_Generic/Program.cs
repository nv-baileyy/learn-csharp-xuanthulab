using System;

namespace Basic_Generic
{
    public class GenericDemo
    {
        public static void swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

    public class GenericClassDemo<T> where T : IComparable
    {
        private T _a;
        private T _b;

        public void SetupValue(T a, T b)
        {
            _a = a;
            _b = b;
        }

        public T GetDefault()
        {
            return default(T);
        }

        public int Compar()
        {
            return (_a.CompareTo(_b));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            var compa = new GenericClassDemo<int>();
            compa.SetupValue(a, b);
            Console.WriteLine(compa.Compar());
        }
    }
}