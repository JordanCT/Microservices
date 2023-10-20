using BCP.Muchik.Infrastructure.CrossCutting.Exceptions;
using System.Net;
using System.Text.Json;

namespace BCP.Muchik.Infrastructure.Gateway.Api.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;

                var exceptionResponseModel = new ExceptionResponseModel();
                exceptionResponseModel.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                exceptionResponseModel.Message = "Token Validation Has Failed. Request Access Denied";

                var exResult = JsonSerializer.Serialize(exceptionResponseModel);
                await httpContext.Response.WriteAsync(exResult);
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;

                var exceptionResponseModel = new ExceptionResponseModel();
                exceptionResponseModel.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                exceptionResponseModel.Message = "You don't have permission to access, the role don't have permission to access.";

                var exResult = JsonSerializer.Serialize(exceptionResponseModel);
                await httpContext.Response.WriteAsync(exResult);
            }
        }
    }
}
