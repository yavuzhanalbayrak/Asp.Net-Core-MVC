using Lezita2.Context;
using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lezita2.Controllers
{
    public class InspectController : Controller
    {
        LezitaDbContext _context = new();
        public IActionResult Index(int id)
        {
            var product = _context.Products.FirstOrDefault(x =>x.Id==id);
            if (product is null)
                return RedirectToAction("Index", "Category");
            return View(product);
        }
    }
}
