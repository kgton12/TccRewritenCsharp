﻿using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Infrastructure
{
    public class TccRewritenCsharpDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=D:\\Estudo C#\\TccRewritenCsharp\\TccRewritenCsharp.Infrastructure\\TccRewritenCsharpDbContext.db");
        }

    }
}