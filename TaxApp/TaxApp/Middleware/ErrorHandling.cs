using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TaxApp.Models.Responses;

namespace TaxApp.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandling> _logger;

        public ErrorHandling(RequestDelegate next, ILogger<ErrorHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception occured in method {context.Request.GetDisplayUrl()}");
                await WriteErrorResponse(context.Response, 500, "UnexpectedError", "An unexpected error has occured");
            }
        }

        private static async Task WriteErrorResponse(HttpResponse response, int statusCode, string errorCode, string description)
        {
            response.StatusCode = statusCode;
            response.ContentType = "application/json";

            var responseObject = new ErrorResponse
            {
                Code = errorCode,
                Description = description
            };

            await response.WriteAsync(JsonConvert.SerializeObject(responseObject));
        }
    }
}
