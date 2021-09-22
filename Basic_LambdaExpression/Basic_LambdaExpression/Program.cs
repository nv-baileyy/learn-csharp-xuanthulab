using System;
using System.Linq;
/*
    Lambda - anonymous function
    1)
    (int a, int b) => bieu_thuc
    

    2)
    (tham_so) => {
        cac_bieu_thuc;
        return bieu_thuc_tra_ve;
    }
*/
namespace Basic_LambdaExpression
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action<string> thongbao = (string s) => Console.WriteLine(s); // ~ delegate void KIEU (string s) == Action<string>
            thongbao?.Invoke("xin chao");
            Action action = () => Console.WriteLine("xin chao cac ban");
            action.Invoke();
            // (int a, int b) =>
            // {
            //     int kq = a + b;
            //     return kq;
            // }
            Action<string, string> welcome;
            welcome = (string msg, string name) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg + " " + name);
                Console.ResetColor();
            };
            welcome?.Invoke("xin chao ---", "Hai");

            Func<int, int, int> tinhtoan; //~deligate int KIEU(int a, int b)
            tinhtoan = (int a, int b) =>
            {
                return a + b;
            };
            Console.WriteLine($"kq: {tinhtoan?.Invoke(1, 2)}");

            int[] mang = { 1, 2, 3, 4, 5, 66 };
            var kq = mang.Select(
                (int x) =>
                {
                    return Math.Sqrt(x);
                }
            );
            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }
            ///
            Action<int> duyet = (int x) =>
            {
                if (x % 2 != 0) Console.WriteLine(x);
            };
            mang.ToList().ForEach(
                duyet
            );
            ///
            var kq1 = mang.Where(
                (x) =>
                {
                    return x % 4 == 0;
                }
            );
            foreach (var item in kq1)
            {
                Console.WriteLine(item);
            };
        }
    }
}