using Microsoft.EntityFrameworkCore;

namespace ECommerec.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Product = modelBuilder.Entity<Product>();
            var Category = modelBuilder.Entity<Category>();
            var OrderItem = modelBuilder.Entity<OrderItem>();
            var Order = modelBuilder.Entity<Order>();


            // Product Relation 
            Product
            .HasMany(oi => oi.OrderItems)
            .WithOne(o => o.Product)
            .HasForeignKey(fk => fk.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            // Category Relation 
            Category
            .HasMany(p => p.Products)
            .WithOne(c => c.Category)
            .HasForeignKey(fk => fk.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            //Order Relation 
            Order
            .HasMany(oi => oi.OrderItems)
            .WithOne(o => o.Order)
            .HasForeignKey(fk => fk.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            // to restore the [property ](status) in the sql sever with the name not a number 
            Order.Property(st => st.Status)
            .HasConversion<string>();

        }
    }
}