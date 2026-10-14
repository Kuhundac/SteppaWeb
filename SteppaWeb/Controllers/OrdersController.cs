using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteppaWeb.Models;

namespace SteppaWeb.Controllers;

[Authorize(Roles = "Admin")]
public class OrdersController : Controller
{
    private readonly SteppaDbContext _context;

    public OrdersController(SteppaDbContext context)
    {
        _context = context;
    }

    // List all orders, newest first
    public IActionResult Index()
    {
        var orders = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .OrderByDescending(o => o.OrderDate)
            .ToList();
        return View(orders);
    }

    // Show the new-order form
    [HttpGet]
    public IActionResult Create()
    {
        LoadDropdowns();
        return View(new Order());
    }

    // Handle the new-order form being submitted
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Order order)
    {
        var product = _context.Products.Find(order.ProductId);
        if (product == null)
        {
            ModelState.AddModelError(nameof(Order.ProductId), "Please choose a product");
        }
        else if (order.Quantity > product.StockQuantity)
        {
            ModelState.AddModelError(nameof(Order.Quantity), $"Only {product.StockQuantity} in stock");
        }

        if (!_context.Customers.Any(c => c.CustomerId == order.CustomerId))
        {
            ModelState.AddModelError(nameof(Order.CustomerId), "Please choose a customer");
        }

        if (!ModelState.IsValid)
        {
            LoadDropdowns();
            return View(order);
        }

        product!.StockQuantity -= order.Quantity;
        order.OrderDate = DateTime.UtcNow;
        _context.Orders.Add(order);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // Fills the Customer and Product dropdowns
    private void LoadDropdowns()
    {
        ViewBag.Customers = new SelectList(_context.Customers.OrderBy(c => c.Name), "CustomerId", "Name");
        ViewBag.Products = new SelectList(_context.Products.OrderBy(p => p.Name), "ProductId", "Name");
    }
}