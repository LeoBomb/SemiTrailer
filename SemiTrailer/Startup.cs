using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Core.Interface;
using UseCases.Interface;
using UseCases.User;
using Infrastructure.SemiTrailer.Queries;
using Core.Services;
using Infrastructure;
using UseCases.RepositoryInterface;
using Infrastructure.Tenant;
using Core.Model;

namespace SemiTrailer
{
    public static class Startup
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;
            builder.Services.Configure<AppsettingOptions>(configuration);
            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
            builder.Services.AddApplicationDbContext(connectionString);
            services.AddSingleton<TenantResolver>();
            services.AddScoped<TenantContext>();
            services.AddSingleton<ITenantService, TenantService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICryptService, CryptService>();
            services.AddScoped<IAuthService, AuthService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };

                    options.Events.OnRedirectToAccessDenied = (context) =>
                    {
                        context.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    };
                });

        }
    }
}
