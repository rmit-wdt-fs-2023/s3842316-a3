using A3.Data;
using X.PagedList;
using A3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace A3.Controllers;

public class OrderedProductController : Controller
{
    private readonly A3Context _context;

    // Constructor
    public OrderedProductController(A3Context context) => _context = context;

    /**
     * Code Adapted From - RMIT/WDT/Week5-Lectorial/MvcMovie
     * and modified to include Paged List
     */
    [HttpGet]
    public async Task<IActionResult> OrderedProduct(string? name, int? page = 1)
    {
        var productNames = _context.OrderedProducts.Include(x => x.Product).
            Select(x => x.Product.Name).Distinct().OrderBy(x => x);

        var orderedProducts = _context.OrderedProducts.Include(x => x.Product).Select(x => x);
        if (!string.IsNullOrEmpty(name))
            orderedProducts = orderedProducts.Where(x => x.Product.Name == name);

        const int pageSize = 5;
        return View(new OrderedProductsViewModel
        {
            Name = new SelectList(await productNames.ToListAsync()),
            // paging
            OrderedProduct = await orderedProducts.OrderBy(x => x.Product.Name).ToPagedListAsync(page, pageSize)
        });
        
    }
}

