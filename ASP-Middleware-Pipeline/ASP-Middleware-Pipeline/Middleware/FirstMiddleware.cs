using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class FirstMiddleware
{
    // RequestDelegate ~ async (HttpContext context ) => {}
    private readonly RequestDelegate _next;
    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    // httpcontext di qua Middleware  trong pipeline
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"URL: {context.Request.Path}");
        // truyen du lieu cho cac Middleware phia sau (Items)
        context.Items.Add("data", $"<p> URL: {context.Request.Path} </p>");
        //await context.Response.WriteAsync();

        // chuyen HttpContext cho Middleware tiep theo
        await _next(context);
    }
}