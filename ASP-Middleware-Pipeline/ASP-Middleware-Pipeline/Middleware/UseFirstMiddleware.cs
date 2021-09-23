using Microsoft.AspNetCore.Builder;
// Extension Method
public static class UseFirstMiddlewareMethod
{
    public static void UseFirstMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<FirstMiddleware>();
    }
}