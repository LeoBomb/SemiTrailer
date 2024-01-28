using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantDb.Tenant
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            return new TenantDbContext(new Core.Model.TenantContext { Tenant = new Core.Model.TenantEntity { ConnectionString =
                "Server=127.0.0.1;Port=5432;Database=Tenant_8;User Id=postgres;Password=postgresqlPass;Minimum Pool Size=5;Maximum Pool Size=50"
            } });
        }
    }
}
