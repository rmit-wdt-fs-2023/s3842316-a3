using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace A3.Models.ViewModels;

public class OrderViewModel
{
    public Order Order { get; set; }

    [Display(Name = "No of Products Ordered")]
    public int TotalOrders { get; set; }
}

