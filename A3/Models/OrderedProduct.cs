using System.ComponentModel.DataAnnotations;

namespace A3.Models;

public class OrderedProduct
{
    // FK to Orders
    public int OrderID { get; set; }
    public Order Order { get; set; }

    // FK to Products
    public int ProductID { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity has to be greater than 0")]
    public int Quantity { get; set; }
}

