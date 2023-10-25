using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int id)
        {
            var category = DbList.categories.FirstOrDefault(x=>x.Id==id);
            if (category is null) 
                return RedirectToAction("Index", "Category");
            ViewBag.CategoryName = category.Name;
            var producs = DbList.products.Where(x => x.CategoryId == id);
            return View(producs);
        }
    }
}
