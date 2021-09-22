using System;

namespace Basic_Event
{
    class Program
    {
        public delegate void SuKienNhapSo(int x);
        // class publisher
        public class Dulieunhap : EventArgs
        {
            public int Data { get; set; }
            public Dulieunhap(int x)
            {
                this.Data = x;
            }
        }
        public class UserInput
        {
            // public event SuKienNhapSo sukiennhapso;
            // ~ delegate void KIEU(object? sender, EvenArgs args) - publisher
            public event EventHandler sukiennhapso;
            public void Input()
            {
                do
                {
                    string s = Console.ReadLine();
                    int i = Int32.Parse(s);
                    // phat di su kien
                    sukiennhapso?.Invoke(this, new Dulieunhap(i));
                } while (true);
            }
        }
        // class subscriber
        public class TinhCan
        {
            public void Sub(UserInput input)
            {
                input.sukiennhapso += Can;
            }
            public void Can(object sender, EventArgs e)
            {
                Dulieunhap dulieunhap = (Dulieunhap)e;
                int i = dulieunhap.Data;

                Console.WriteLine($"Can bac 2 cua so i la {Math.Sqrt(i)}");
            }
        }
        public class BinhPhuong
        {
            public void Sub(UserInput input)
            {
                input.sukiennhapso += bp;
            }
            public void bp(object sender, EventArgs e)
            {
                Dulieunhap dulieunhap = (Dulieunhap)e;
                int i = dulieunhap.Data;
                Console.WriteLine($"binh phuong cua so i la {i * i}");
            }
        }
        static void Main(string[] args)
        {
            // publisher
            UserInput userInput = new UserInput();

            userInput.sukiennhapso += (object sender, EventArgs e) =>
            {
                Dulieunhap dulieunhap = (Dulieunhap)e;
                int i = dulieunhap.Data;
                Console.WriteLine($"ban vu nhap so {i}");
            };

            //
            TinhCan tinhcan = new TinhCan();
            tinhcan.Sub(userInput);
            BinhPhuong bp = new BinhPhuong();
            bp.Sub(userInput);
            //
            // SuKienNhapSo sk = Can1;
            // userInput.sukiennhapso = sk;            
            userInput.Input();
        }
    }
}
