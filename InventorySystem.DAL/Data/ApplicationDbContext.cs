using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Inventory.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var order = modelBuilder.Entity<Order>();
            var orderItem = modelBuilder.Entity<OrderItem>();
            var product = modelBuilder.Entity<Product>();

            // Properties
            order.Property(o => o.Status).HasConversion<string>().HasMaxLength(20);
            order.Property(o => o.TotalAmount).HasPrecision(18, 2);
            orderItem.Property(i => i.UnitPrice).HasPrecision(18, 2);
            product.Property(p => p.Price).HasPrecision(18, 2);

            // Relations
            product.HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            order.HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}