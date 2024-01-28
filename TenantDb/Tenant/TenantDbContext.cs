using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TenantDb.Tenant.Data.Entity;
using UseCases;

namespace Infrastructure.Data
{
    public class TenantDbContext : DbContext
    {
        private readonly TenantContext _tenantContext;

        public TenantDbContext(TenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }
        public TenantDbContext(DbContextOptions<TenantDbContext> options, TenantContext tenantContext) : base(options)
        {
            _tenantContext = tenantContext;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_tenantContext.Tenant.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public async Task CreateNewDb(string newConnectionString)
        {
            _tenantContext.Tenant.ConnectionString = newConnectionString;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
        }

        public DbSet<DailyReport> DailyReport { get; set; }
    }
}
