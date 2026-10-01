using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Products()
        {
            var products = _context.Products.ToList();
            return View(products);
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
    }
}
