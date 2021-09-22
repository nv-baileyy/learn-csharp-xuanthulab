using System;

namespace Basic_Struct_Enum
{
    public struct Product
    {
        // du lieu
        // phuong thuc
        // constructor
        public string Name;

        public double Price;

        public string Getinfor()
        {
            return $"ten san pham {Name}, gia {Price}";
        }

        public Product(string _name, double _price)
        {
            this.Name = _name;
            this.Price = _price;
        }
    }

    internal enum HOCLUC
    {
        Kem = 1, // - 0
        Trungbinh = 2, // -1
        Kha = 3, // -2
        Gioi = 6 // -3
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Product sp1;
            sp1.Price = 100;
            sp1.Name = "IPHONE";
            Console.WriteLine(sp1.Getinfor());
            Product sp2 = new Product("Nokia", 900);
            Console.WriteLine(sp2.Getinfor());

            int x = (int)HOCLUC.Gioi;

            Console.WriteLine(x);
        }
    }
}