using System.Net;
using Newtonsoft.Json;
using Transactions.Core.Enums;
using Newtonsoft.Json.Serialization;
using Transactions.Core.Domain.Dtos.Base;
using Transactions.Core.Domain.DomainObjects;

namespace Transactions.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException domainException)
            {
                await HandleDomainExceptionAsync(context, domainException);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleDomainExceptionAsync(HttpContext context, DomainException exception)
        {
            ApiResponse<object> response = new(false, new NotificationsResponse(exception.Code, exception.Message));
            string json = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(json);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiResponse<object> response = new(false, new NotificationsResponse((int)HttpStatusCode.InternalServerError, ErrorMessage.InternalServerError));
            string json = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(json);
        }
    }
}
