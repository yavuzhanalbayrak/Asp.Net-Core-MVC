using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            ViewBag.Categories = DbList.categories;
            var products = DbList.products;
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProducts()
        {
            ViewBag.Categories = DbList.categories;
            return View();
        }
        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            DbList.products.Add(product);
            return RedirectToAction("GetProducts");
        }
        public IActionResult GetCategories()
        {
            return View();
        }

    }
}
