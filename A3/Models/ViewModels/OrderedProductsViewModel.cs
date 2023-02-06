using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace A3.Models.ViewModels;

/**
 * Code Adapted From - RMIT/WDT/Week5-Lectorial/MvcMovie
 */
public class OrderedProductsViewModel
{
    public IPagedList<OrderedProduct> OrderedProduct { get; set; }
    public SelectList Name { get; set; }
    public string ProductName { get; set; }
}

