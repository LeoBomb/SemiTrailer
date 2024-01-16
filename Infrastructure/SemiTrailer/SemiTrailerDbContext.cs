using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.SemiTrailer.Data.Entity;

namespace Infrastructure.SemiTrailer
{
    public class SemiTrailerDbContext : DbContext
    {
        public SemiTrailerDbContext(DbContextOptions<SemiTrailerDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => e.HasData(new User { Id = 1, Name = "Morrison", Description = "boss", IsEnable = true, Email = "test@morr.com", Password = "$2a$12$/TJ5etIYa9oVJVcEcO0juOYaGQgt1viLJxZlJPoglr6gVWvtHnLt6" }));
        }

        public DbSet<User> User { get; set; }
    }
}
