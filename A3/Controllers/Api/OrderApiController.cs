using System.Net;
using A3.Data;
using A3.Models;
using Microsoft.AspNetCore.Mvc;

namespace A3.Controllers.Api;

/**
 * http://localhost:5100/"Corrosponding End Point"
 */
[ApiController]
[Route("orderapi")]
public class OrderApiController : ControllerBase
{
    private readonly A3Context _context;

    // Constructor
    public OrderApiController(A3Context context) => _context = context;

    /** 
     * GET: orderapi
     * https://localhost:5100/orderapi
     */
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders.ToList();
        if (orders == null || !orders.Any())
            return NotFound(); // Returns 404

        return Ok(orders);
    }

    /** 
     * GET orderapi/{id}
     * https://localhost:5201/orderapi/{Id}
     */
    [HttpGet("{id}")]
    public IActionResult GetOrderedProductQuantity(int id)
    {
        var orderedProducts = _context.OrderedProducts.Where(x => x.OrderID == id).ToList();
        if (orderedProducts == null || !orderedProducts.Any())
            return NotFound(); // Returns 404

        var quantity = orderedProducts.Sum(x => x.Quantity);
        return Ok(quantity);
    }
}

