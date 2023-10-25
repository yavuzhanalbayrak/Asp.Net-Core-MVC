using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class InspectController : Controller
    {
        public IActionResult Index(int id)
        {
            var product = DbList.products.FirstOrDefault(x =>x.Id==id);
            if (product is null)
                return RedirectToAction("Index", "Category");
            return View(product);
        }
    }
}
