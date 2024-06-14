using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Infrastructure.Entities;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Infrastructure
{
    public class TccRewritenCsharpDbContext(ServiceEnvironment environment = ServiceEnvironment.Production) : DbContext
    {
        internal ServiceEnvironment Environment { get; set; } = environment;
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment == ServiceEnvironment.Production)
            {
                optionsBuilder.UseSqlite(ConfigurationDb.ConnectionString);
            }
            else if (Environment == ServiceEnvironment.Development)
            {
                optionsBuilder.UseInMemoryDatabase("MyDatabase");
            }
        }
    }
}
