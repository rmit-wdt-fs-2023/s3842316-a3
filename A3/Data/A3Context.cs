using Microsoft.EntityFrameworkCore;

namespace A3.Data;

public class A3Context : DbContext
{
    public A3Context(DbContextOptions<A3Context> options) : base(options)
    { }
}
