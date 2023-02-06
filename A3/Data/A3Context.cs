using A3.Models;
using Microsoft.EntityFrameworkCore;

namespace A3.Data;

public class A3Context : DbContext
{
    public A3Context(DbContextOptions<A3Context> options) : base(options)
    { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedProduct> OrderedProducts { get; set; }
    public DbSet<Product> Products { get; set; }

    // Fluent-API.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite primary key.
        builder.Entity<OrderedProduct>().HasKey(x => new { x.OrderID, x.ProductID });
    }
}
