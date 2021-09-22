using System;

namespace Basic_QuaTaiToanTu
{
    internal class Vector
    {
        private double x;
        private double y;

        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public void Infor()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator +(Vector v1, double x)
        {
            return new Vector(v1.x + x, v1.y + x);
        }

        // Indexer[chiso]
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;

                    case 1:
                        y = value;
                        break;

                    default:
                        throw new Exception("Chi so sai");
                }
            }
            get
            {
                switch (i)
                {
                    case 0:
                        return x;

                    case 1:
                        return y;

                    default:
                        throw new Exception("Chi so sai");
                }
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Vector v1 = new Vector(2, 3);
            Vector v2 = new Vector(1, 1);

            var v33 = v1 + v2;
            v33 = v1 + 10;
            v1.Infor();
            v2.Infor();
            v33.Infor();

            v33[0] = 5;
            v33[1] = 6;
            v33.Infor();
        }
    }
}