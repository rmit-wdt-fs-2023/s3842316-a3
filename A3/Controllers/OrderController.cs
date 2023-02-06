using A3.Models;
using X.PagedList;
using Newtonsoft.Json;
using A3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace A3.Controllers;

public class OrderController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private HttpClient Client => _clientFactory.CreateClient("api");

    // Controller
    public OrderController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    /** 
     * GET: orders
     */
    public async Task<IActionResult> Order(int? page = 1)
    {
        // API Call
        var response = await Client.GetAsync("orderapi");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction("Index", "Home");

        // Result/Deserilize
        var result = await response.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(result);

        // Gets Total number of orders and adds to view model
        var orderViewModels = new List<OrderViewModel>();
        foreach (var order in orders)
        {
            // API Call 
            var response2 = await Client.GetAsync($"orderapi/{order.OrderID}");
            if (!response2.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            // Result
            var orderCount = int.Parse(await response2.Content.ReadAsStringAsync());

            // Adds data to view model
            orderViewModels.Add(
                new OrderViewModel
                {
                    Order = order,
                    TotalOrders = orderCount
                });
        }

        // paging 
        const int pageSize = 5;
        var pagedList = orderViewModels.ToPagedList((int)page, pageSize);
        return View(pagedList);
    }
}

