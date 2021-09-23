using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text;
using System.Threading.Tasks;

public class TestOptionMiddleware : IMiddleware
{
    private TestOptions options { get; set; }
    private ProductName products { get; set; }

    // IOptions and ProductName has adreadly resigned into services
    // Constructer of middleware will injected it if it be called
    public TestOptionMiddleware(IOptions<TestOptions> _options, ProductName _products)
    {
        options = _options.Value;
        products = _products;
    }

    async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Da di qua TestOptionMiddleware\n");
        StringBuilder ss = new StringBuilder();
        ss.Append("TestOption:\n");
        ss.Append($"opt_key1: {options.opt_key1} \n");
        ss.Append($"opt_key2.k1: {options.opt_key2.k1}");
        ss.Append($"opt_key2.k2: {options.opt_key2.k2}\n");
        ss.Append("Product name: ");
        products.products.ForEach(p => ss.Append(p + " "));
        await context.Response.WriteAsync(ss.ToString());
        // if dont have code below -> endpoint
        await next(context);
    }
}