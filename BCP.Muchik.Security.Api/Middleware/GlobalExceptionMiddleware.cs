using BCP.Muchik.Infrastructure.CrossCutting.Exceptions;
using System.Net;
using System.Text.Json;

namespace BCP.Muchik.Security.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception currentException)
        {
            httpContext.Response.ContentType = "application/json";

            var exceptionResponseModel = new ExceptionResponseModel();

            switch (currentException)
            {
                case BusinessException ex:
                    exceptionResponseModel.StatusCode = (int)HttpStatusCode.OK;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    exceptionResponseModel.Message = ex.Message;
                    exceptionResponseModel.StackTrace = string.Empty;
                    break;
                case NullReferenceException ex:
                    exceptionResponseModel.StatusCode = (int)HttpStatusCode.NotFound;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionResponseModel.Message = ex.Message;
                    exceptionResponseModel.StackTrace = string.Empty;
                    break;
                default:
                    exceptionResponseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exceptionResponseModel.Message = "Ocurrió un error interno, vuelva a intentar en unos minutos.";
                    exceptionResponseModel.StackTrace = string.Empty;
                    break;
            }

            var jsonResult = JsonSerializer.Serialize(exceptionResponseModel);

            await httpContext.Response.WriteAsJsonAsync(jsonResult);
        }
    }
}
