using System;

namespace Basic_Inherent
{
    internal class Program
    {
        // sealed - Niem phong lai 1 lop nao do, k the ke thua
        public class Animal
        {
            public Animal()
            {
                Console.WriteLine("khoi tao animal");
            }

            public Animal(string msg)
            {
                Console.WriteLine("khoi tao animal (2)" + msg);
            }

            public int Legs { get; set; }
            public float Weight { get; set; }

            public void ShowLegs()
            {
                Console.WriteLine($"Animal Legs: {Legs}");
            }
        }

        public class Cat : Animal
        {
            public string Food;

            // chi dinh dung constructor co tham so khoi tao ma msg
            public Cat(string msg) : base(msg)
            {
                this.Legs = 4;
                this.Food = "Mouse";
                Console.WriteLine("Khoi tao lop cat");
            }

            public void Eat()
            {
                Console.WriteLine($"Thuc an: {Food}");
            }

            // re-use method of parent class
            public new void ShowLegs()
            {
                Console.WriteLine($" Cat Legs: {Legs}");
            }

            public void ShowInfor()
            {
                base.ShowLegs();
                ShowLegs();
            }
        }

        private class A
        { }

        private class B : A
        { }

        private class C : B
        { }

        // A -> B -> C
        // A = new B(), new C()
        // C not new A()
        private static void Main(string[] args)
        {
            Animal animal = new Animal();
            Cat cat = new Cat("abc");
        }
    }
}