using Lezita2.Context;
using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lezita2.Controllers
{
    public class HomeController : Controller
    {
        LezitaDbContext _context = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categoriesCount = _context.Categories.Count();
           
            if (categoriesCount>3)
            {
                ViewBag.CategoriesCount = 3;
                var categories = _context.Categories.Take(3).ToList();
                return View(categories);
            }
            else if (categoriesCount>0)
            {
                ViewBag.CategoriesCount = categoriesCount;
                var categories = _context.Categories.ToList();
                return View(categories);
            }
            ViewBag.CategoriesCount = categoriesCount;
            return View();
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