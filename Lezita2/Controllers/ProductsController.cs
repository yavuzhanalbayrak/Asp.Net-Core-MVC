using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int id)
        {
            var producs = DbList.products.Where(x => x.CategoryId == id);
            return View(producs);
        }
    }
}
