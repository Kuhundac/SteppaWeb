using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteppaWeb.Models;
using System.Diagnostics;

namespace SteppaWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly SteppaDbContext _context;

        public HomeController(SteppaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products(string? search, string? sort, bool lowStock = false)
        {
            const int LowStockLimit = 20;

            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{search}%")
                                      || EF.Functions.Like(p.Color, $"%{search}%"));
            }

            if (lowStock)
            {
                query = query.Where(p => p.StockQuantity <= LowStockLimit);
            }

            query = sort switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "stock" => query.OrderBy(p => p.StockQuantity),
                "stock_desc" => query.OrderByDescending(p => p.StockQuantity),
                _ => query.OrderBy(p => p.Name)
            };

            ViewData["Search"] = search;
            ViewData["Sort"] = sort;
            ViewData["LowStock"] = lowStock;
            return View(query.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            var productToDelete = _context.Products.Find(product.ProductId);
            if (productToDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }
    }
}