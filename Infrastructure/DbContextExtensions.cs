﻿using Infrastructure.Data;
using Infrastructure.SemiTrailer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class AppDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SemiTrailerDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<TenantDbContext>();
        }
    }
}
