using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteppaWeb.Models;

namespace SteppaWeb.Controllers;

[Authorize(Roles = "Admin")]
public class CustomersController : Controller
{
    private readonly SteppaDbContext _context;

    public CustomersController(SteppaDbContext context)
    {
        _context = context;
    }

    // List all customers
    public IActionResult Index()
    {
        var customers = _context.Customers.OrderBy(c => c.Name).ToList();
        return View(customers);
    }

    // Show the add-customer form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Handle the add-customer form being submitted
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return View(customer);
        }

        _context.Customers.Add(customer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}