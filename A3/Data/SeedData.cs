using A3.Models;

namespace A3.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<A3Context>();

        // Look for Products
        if (context.Products.Any())
            return; // DB already been seeded.

        Populate(context);
    }

    // Populates the db 
    private static void Populate(A3Context context)
    {
        // Products
        var p1 = new Product {Name = "S5000", Price = 10.00m };
        var p2 = new Product { Name = "E8900", Price = 320.50m };
        var p3 = new Product { Name = "S9000", Price = 5900.00m };
        var p4 = new Product { Name = "P2300 IS", Price = 50.90m };

        // Orders
        var o1 = new Order {
            OrderDate = DateTime.UtcNow,
            CustomerName = "Seeded Customer1",
            DeliveryAddress = "2 Random Street",
            DeliveryDate = null
        };
        var o2 = new Order
        {
            OrderDate = DateTime.UtcNow,
            CustomerName = "New Seed",
            DeliveryAddress = "11 Unknown Way",
            DeliveryDate = DateTime.UtcNow.AddMonths(1)
        };

        
        context.Products.AddRange(p1, p2, p3, p4);
        context.Orders.AddRange(o1, o2);
        // OrderedProducts
        context.OrderedProducts.AddRange(
            new OrderedProduct
            {
                Order = o1,
                Product = p1,
                Quantity = 5
            },
            new OrderedProduct
            {
                Order = o1,
                Product = p3,
                Quantity = 10
            },
            new OrderedProduct
            {
                Order = o2,
                Product = p2,
                Quantity = 20
            },
            new OrderedProduct
            {
                Order = o2,
                Product = p4,
                Quantity = 3
            });

        context.SaveChanges();
    }

}

