using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Networking
{
    public class HttpMessageHandlerDemo
    {
        public class MyHttpClientHander : HttpClientHandler
        {
            public MyHttpClientHander(CookieContainer cookieContainer)
            {
                UseCookies = true;
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                CookieContainer = cookieContainer;
                AllowAutoRedirect = true;
            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Start connnecting... " + request.RequestUri.ToString());
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                Console.WriteLine("Completed downloading");
                return response;
            }
        }

        public class ChangeUri : DelegatingHandler
        {
            public ChangeUri(HttpMessageHandler inner) : base(inner)
            {
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Check URI...");
                string host = request.RequestUri.Host.ToLower();
                if (host.Contains("google.com"))
                {
                    Console.WriteLine("Change from google.com to bing.com");
                    request.RequestUri = new Uri("https://bing.com");
                }
                return base.SendAsync(request, cancellationToken);
            }
        }

        public class DenyAccessFacebook : DelegatingHandler
        {
            public DenyAccessFacebook(HttpMessageHandler inner) : base(inner)
            {
            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Check accessing to Facebook.com...");
                string host = request.RequestUri.Host.ToLower();
                if (host.Contains("facebook.com"))
                {
                    var responce = new HttpResponseMessage(HttpStatusCode.OK);
                    responce.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes("Facebook can not accessable!"));
                    return await Task.FromResult<HttpResponseMessage>(responce);
                }
                return await base.SendAsync(request, cancellationToken);
            }
        }

        public static async Task GetWebContent()
        {
            var cookies = new CookieContainer();
            /// chuon handler -> check facebook -> redirect if host is google
            MyHttpClientHander buttonHander = new MyHttpClientHander(cookies);
            ChangeUri changeUriHandler = new ChangeUri(buttonHander);
            DenyAccessFacebook denyAccessFacebook = new DenyAccessFacebook(changeUriHandler);

            ///

            using var socket = new SocketsHttpHandler();
            socket.AllowAutoRedirect = true;
            socket.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            socket.UseCookies = true;
            socket.CookieContainer = cookies;

            string url = "https://google.com";
            using HttpClient httpClient = new HttpClient(denyAccessFacebook);
            //----------------------------------------------------------------//
            // create request messages to server
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            // create content to send
            var para = new List<KeyValuePair<string, string>>();
            para.Add(new KeyValuePair<string, string>("key1", "giatri 1"));
            para.Add(new KeyValuePair<string, string>("key2", "giatri 2"));
            var content = new FormUrlEncodedContent(para);
            httpRequestMessage.Content = content;

            // receive responce
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            cookies.GetCookies(new Uri(url)).ToList().ForEach(
                c =>
                {
                    Console.WriteLine($"{c.Name}, : {c.Value}");
                }
            );

            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(html);
        }
    }
}