using A3.Models;
using Microsoft.EntityFrameworkCore;

namespace A3.Data;

public class A3Context : DbContext
{
    public A3Context(DbContextOptions<A3Context> options) : base(options)
    { }

    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderedProducts> OrderedProducts { get; set; }
    public DbSet<Products> Products { get; set; }

}
