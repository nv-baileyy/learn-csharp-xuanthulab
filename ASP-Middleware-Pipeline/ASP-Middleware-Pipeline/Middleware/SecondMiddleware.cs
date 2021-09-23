using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SecondMiddleware : IMiddleware
{

    /*
        URL: "/porn"
            -- Khong dc goi cac Middleware phia sau (Terminal Middleware)
            -- Ban khong duoc truy cap
            -- Header response - Second Middleware : ban khong duoc truy cap
        URL: != "/porn"
            -- Forware RequestDelegate cho cac middleware phia sau
            -- ban duoc phep truy cap
            -- Header response - Second Middleware : ban duoc phep truy cap
    */
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {


        if (context.Request.Path.ToString().Contains("/porn"))
        {
            //note: setup header before write HttpMessageResponse
            context.Response.Headers.Add("Second_Middleware", "ban khong phep truy cap");
            await context.Response.WriteAsync("Ban khong duoc truy cap");
            //nhan du lieu tu Middleware truoc do
            var dataFirstMiddleware = context.Items["data"];
            if (dataFirstMiddleware != null) await context.Response.WriteAsync(dataFirstMiddleware.ToString());

        }
        else
        {
            context.Response.Headers.Add("Second_Middleware", "ban duoc phep truy cap");
            await context.Response.WriteAsync("Ban duoc phep truy cap");
            await next(context);
        }

    }
}