using A3.Data;
using A3.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static A3.Utils.HelperMethods;

namespace A3.Controllers;

public class ProductController : Controller
{
    private readonly A3Context _context;

    // Constructor
    public ProductController(A3Context context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Product(int? page = 1)
    {
        // paging
        const int pageSize = 5;
        var pagedList = await _context.Products.ToPagedListAsync(page, pageSize);

        return View(pagedList);
    }

    [HttpGet]
    public async Task<IActionResult> AddProduct() => View();

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        // Amount validation
        if (product.Price <= 0)
            ModelState.AddModelError(nameof(product.Price), "Amount must be positive.");
        if (product.Price.HasMoreThanTwoDecimalPlaces())
            ModelState.AddModelError(nameof(product.Price), "Amounts can't have more than 2 decimal places");
        if (!ModelState.IsValid)
        {
            ViewBag.Price = product.Price;
            return View(product);
        }

        // Adds Product to database
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Product));
    }
}

