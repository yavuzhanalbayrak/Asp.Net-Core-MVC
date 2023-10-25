using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var categoryies = DbList.categories;
            return View(categoryies);
        }
    }
}
