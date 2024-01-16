using Core.Model;
using Infrastructure.Data;
using Infrastructure.Tenant;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;

namespace SemiTrailer
{
    public class HttpTenantResolveMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpTenantResolveMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,
            TenantResolver tenantResolver,
            TenantContext tenantContext)
        {
            var claim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var tenant = await tenantResolver.ResolveByLogin(Convert.ToInt32(claim.Value));
                tenantContext.Tenant = tenant;
            }
            await _next.Invoke(context);
        }
    }
}
