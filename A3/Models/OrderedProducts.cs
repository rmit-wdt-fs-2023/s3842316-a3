using System.ComponentModel.DataAnnotations;

namespace A3.Models;

public class OrderedProducts
{
    // FK to Orders
    public int OrderID { get; set; }
    public Orders Order { get; set; }

    // FK to Products
    public int ProductID { get; set; }
    public Products Product { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity has to be greater than 0")]
    public int Quantity { get; set; }
}

