using Lezita2.Context;
using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class CategoryController : Controller
    {
        LezitaDbContext _context = new();
        public IActionResult Index()
        {
            var categoryies = _context.Categories.ToList();
            return View(categoryies);
        }
    }
}
