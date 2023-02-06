using A3.Data;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

}

