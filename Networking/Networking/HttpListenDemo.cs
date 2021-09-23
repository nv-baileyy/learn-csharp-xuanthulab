using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Networking
{
    internal class HttpListenDemo1
    {
        private HttpListener server;

        public HttpListenDemo1(string[] pre)
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("This server is not supported HttpListener!");
            }
            server = new HttpListener();
            pre.ToList().ForEach(
                p => server.Prefixes.Add(p)
            );
        }

        public async Task Start()
        {
            Console.WriteLine("Server is starting...");
            server.Start();
            Console.WriteLine("Server started");
            HttpListenerContext context = await server.GetContextAsync();
            Console.WriteLine("A client connected");
            await DoProcesS(context);
        }

        public async Task DoProcesS(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            Console.WriteLine($" {request.HttpMethod} : {request.RawUrl} : {request.Url.AbsolutePath}");
            Stream outputStream = response.OutputStream;

            outputStream.Close();
        }
    }
    public class HttpListenerDemo
    {
        public async static Task Process()
        {
            Console.WriteLine($"HttpListener supported: {HttpListener.IsSupported}");
            var server = new HttpListener();
            server.Prefixes.Add("https://*:8080/"); // https://[chap nhap moi ip address] : o cong 8080, mac dinh 80 cho http
            server.Start();
            Console.WriteLine("Server is started");
            do
            {
                // async - doi cho toi khi co ket noi thi moi thuc hien cac cau lenh phia sau
                HttpListenerContext context = await server.GetContextAsync();
                Console.WriteLine("Connected");
                HttpListenerResponse response = context.Response;
                response.Headers.Add("conten-type", "text/html");

                Stream outputStream = response.OutputStream; // data sent to client
                string data = "<h1> Hello, I love you so much! </h1>";
                byte[] byte_msg = System.Text.Encoding.UTF8.GetBytes(data);
                await outputStream.WriteAsync(byte_msg, 0, byte_msg.Length);
                outputStream.Close();

            } while (server.IsListening);
        }

    }
}