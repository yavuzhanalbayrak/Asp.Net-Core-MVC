using Lezita2.Context;
using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class ProductsController : Controller
    {
        LezitaDbContext _context = new();
        public IActionResult Index(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==id);
            if (category is null) 
                return RedirectToAction("Index", "Category");
            ViewBag.Category = category;
            var producs = _context.Products.Where(x => x.CategoryId == id);
            return View(producs);
        }
    }
}
