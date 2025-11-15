
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace TaskManager.Api.Middleware
{
    public class ValidationExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors
                    .GroupBy(e=> e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                var result = JsonSerializer.Serialize(new { errors });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
