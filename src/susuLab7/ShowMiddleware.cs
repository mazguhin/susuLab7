using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace susuLab7
{
    public class ShowMiddleware
    {
        private readonly RequestDelegate _next;
        public ShowMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/show")
            {
                if (context.Request.Query.ContainsKey("id"))
                    await context.Response.WriteAsync("Passed value: " + context.Request.Query["id"]);
                else
                    await context.Response.WriteAsync("Value is missing");
            }
            else
            {
                await context.Response.WriteAsync("Page not found");
            }
        }
    }
}
