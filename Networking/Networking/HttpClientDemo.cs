using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Networking
{
    public class HttpClientDemo
    {
        private static void UrlDemo()
        {
            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url);
            uri.GetType().GetProperties().ToList().ForEach(
                (System.Reflection.PropertyInfo p) =>
                {
                    Console.WriteLine($"{p.Name} : {p.GetValue(uri)}");
                }
            );
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
        }

        private static void HostDemo()
        {
            string url = "https://google.com.vn";
            Console.WriteLine(Dns.GetHostName());
            Uri uri = new Uri(url);
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine(entry.HostName);
            entry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));
        }

        private static void PingDemo()
        {
            var ping = new Ping();
            Uri uri = new Uri("https://google.com.vn");
            var pingReply = ping.Send(uri.Host);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
            }
        }

        private static void ShowHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("Show header");
            headers.ToList().ForEach(
                (header) =>
                {
                    Console.WriteLine(header.Key + " : " + header.Value);
                }
            );
        }

        private static async Task<string> GetWebContent(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                ShowHeader(httpResponseMessage.Headers);
                string html = await httpResponseMessage.Content.ReadAsStringAsync();
                return html;
            }
            catch
            {
                return "Loi";
            }
        }

        private static async Task<byte[]> DownloadDataByte(string url)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            ShowHeader(httpResponseMessage.Headers);
            var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
            return bytes;
        }

        private static async Task DownloadStream(string url, string filename)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            Console.WriteLine($"Status code: {httpResponseMessage.StatusCode}");
            using Stream stream = httpResponseMessage.Content.ReadAsStream();

            FileStream fileStreamWrite = File.OpenWrite(filename);

            int SIZEBUFFER = 5000;
            byte[] buffer = new byte[SIZEBUFFER];
            bool endread = false;
            int count = 0;
            do
            {
                int byte_effected = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                endread = (byte_effected != 0) ? false : true;
                if (!endread)
                {
                    Console.WriteLine(count++);
                    await fileStreamWrite.WriteAsync(buffer, 0, SIZEBUFFER);
                }
            } while (!endread);
        }

        private static async Task SendReceiveRequest()
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            // httpRequestMessage.Content => Form HTML, Json, File..
            //-----------------------------------------------
            // POST => Form HTML
            /*
                key1 => value1 ~ [Input]
                key2 => [value2-1, value2-2] [multi select]
            */
            // using html form content
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
            var c = new FormUrlEncodedContent(parameters);
            //httpRequestMessage.Content = c;
            // upload json file to server
            string jsonContent = @"{
                ""key1"" : ""value1"",
                ""key2"" : ""value2""
            }";
            Console.WriteLine(jsonContent);
            var ct = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            //httpRequestMessage.Content = ct;
            ///
            // Upload file 1.txt
            var cont = new MultipartFormDataContent();
            FileStream fileUpload = File.OpenRead("1.txt");
            var streamContent = new StreamContent(fileUpload);
            cont.Add(streamContent, "fileUpload", "abc.txt");
            cont.Add(new StringContent("Value1"), "key1");

            httpRequestMessage.Content = cont;
            ////
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            ShowHeader(httpResponseMessage.Headers);
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        private static async Task Process(string[] args)
        {
            // string url = "https://images.theconversation.com/files/350865/original/file-20200803-24-50u91u.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=1200.0&fit=crop";
            // Uri uri = new Uri(url);
            // var Task = DownloadDataByte(url);

            // byte[] bytes = await Task;
            // string filename = "i.jpg";
            // FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            // fs.Write(bytes, 0, bytes.Length);
            //await DownloadStream(url, "cat.jpg");
            await SendReceiveRequest();
        }
    }
}