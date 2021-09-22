using System;

namespace Basic_ExceptionHandling
{
    internal class Program
    {
        // custom exception, inheren from base class Exception
        // When use, it'll call Contructor of Exception
        private class NameEmptyException : Exception
        {
            public NameEmptyException() : base("Ten phai khac rong")
            {
            }
        }

        private static void Register(string name, int old)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameEmptyException();
            }
            Console.WriteLine($"Xin chao {name} ({old})");
        }

        private static void Main(string[] args)
        {
            try
            {
                Register("", 12);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " \n " + e.GetType().Name);
            }
        }
    }
}