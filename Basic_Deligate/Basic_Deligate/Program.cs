using System;
// deligate (Type) bien = phuongthuc, là kiểu tham chiếu 
// Action, Func : deligate - generic
// Action ~ deligate void KIEU ()
// Func : giống với deligate nhưng có kiểu trả về 
namespace Basic_Deligate
{
    internal class Program
    {
        public delegate void ShowLog(string message);

        private static void Infor(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        private static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        private static int tong(int a, int b) => a + b;

        private static int hieu(int a, int b) => a - b;

        private static void tong1(int a, int b, ShowLog log)
        {
            int kq = a + b;
            log?.Invoke($"tong la: {kq}");
        }

        private static void Main(string[] args)
        {
            ShowLog log = null;
            log += Infor;
            log += Warning;
            log?.Invoke("xin chao cac ban");
            //
            //Action action;  // ~ deligate voi KIEU();
            //Action<string, int> action1; // ~ deligate void KIEU(string s, int i);

            Action<string> action2;  //~ deligate void KIEU(string s)
            action2 = Warning;
            action2 += Infor;
            action2.Invoke("Thong bao tu action");
            //Func<int> f1; // ~ deligate int KIEU();
            //Func<string, double, string> f2; // ~ deligate string KIEU(string s, double d)
            Func<int, int, int> tinhtoan; //~deligate int KIEU(int a, int b)
            tinhtoan = tong;
            int a = 9;
            int b = 19;
            Console.WriteLine($"tong la: {tinhtoan.Invoke(a, b)}");
            tong1(2, 3, Infor);
        }
    }
}