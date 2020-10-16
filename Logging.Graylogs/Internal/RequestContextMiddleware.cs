using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Logging.Graylogs.Internal
{
    public class RequestContextMiddleware
    {
        private static readonly AsyncLocal<RequestContext> RequestContextStorage = new AsyncLocal<RequestContext>();

        private readonly RequestDelegate _next;

        public RequestContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            RequestContextStorage.Value = new RequestContext(Guid.NewGuid().ToString());
            await _next(context);
        }

        public static RequestContext CurrentRequest => RequestContextStorage.Value;
    }
}