using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Basic_Async_Await
{
    internal class Program
    {
        private static void doSomething(int second, string msg, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10}, Starting....");
                Console.ResetColor();
            }

            string a = "abc";
            lock (a)
            {
            }

            for (int i = 0; i < second; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,10}, {i,2}");
                    Console.ResetColor();

                    Thread.Sleep(1000);
                }
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.ResetColor();
                Console.WriteLine($"{msg,10},end.");
            }
        }

        private static async Task task2()
        {
            Task t2 = new Task(
                () =>
                {
                    doSomething(10, "t2", ConsoleColor.Green);
                }
            );
            t2.Start(); // Thread
            await t2;
            // t2.Wait();
            Console.WriteLine("t2 da hoan thanh");
        }

        private static async Task task3()
        {
            Task t3 = new Task(
            (object ob) =>
            {
                String tentacvu = Convert.ToString(ob);
                doSomething(4, tentacvu, ConsoleColor.Yellow);
            }, "T3"

            );
            t3.Start(); // Thread
            await t3;
            //t3.Wait();
            Console.WriteLine("t3 da hoan thanh");
        }

        // async/ await

        private static async Task Abc()
        {
            /*  Task task = new Task(()=> {
                  // cac chi thi
              });
              task.Start();
              await task;
              //....*/
        }

        private static async Task<string> task4()
        {
            Task<String> t4 = new Task<string>(
           () =>
           {
               doSomething(10, "t4", ConsoleColor.Green);
               return "return from t4";
           }
           ); // ()=>{return string}
            t4.Start();
            string kq = await t4;
            Console.WriteLine("T4 DA HOAN THANH");
            return kq;
        }

        private static async Task<string> task5()
        {
            Task<String> t5 = new Task<string>(
              (object ob) =>
              {
                  string t = (string)ob;
                  doSomething(4, t, ConsoleColor.Yellow);
                  return $"return from {t}";
              }, "t5"
            );
            t5.Start();
            string kq = await t5;

            Console.WriteLine("T5 DA HOAN THANH");
            return kq;
        }

        /*static async Task<Object> Abc(string url)
        {
            Task<Object> task = new Task<object>(
                () =>
                {
                    /// cac tac vu
                    return new object();
                }
            );
            task.Start();
            object kq = await task;
            return kq;
        }*/

        private static async Task<string> GetWebContent(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("bat dau tai");
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            Console.WriteLine("bat dau doc noi dung");
            string content = await kq.Content.ReadAsStringAsync();
            Console.WriteLine("hoan thanh");
            return content;
        }

        private static async Task Main(string[] args)
        {
            // asynchronous
            // task
            /*Task t2 = task2();
            Task t3 = task3();*/
            // Task<T>

            var task = GetWebContent("https://xuanthulab.net");

            /* Task<string> t4 =  task4();
             Task<string> t5 = task5();*/

            doSomething(6, "t1", ConsoleColor.Magenta); // Thread
            string content = await task;
            Console.WriteLine(content);
            //
            /*var kq4 = await t4;
            var kq5 = await t5*/
            ;

            /* Console.WriteLine($"kq4 : {kq4}, kq5: {kq5}");*/
            /*Task.WaitAll(t2, t3);*/
            /* await t2;
             await t3;*/
            Console.WriteLine("press anykey");
        }
    }
}