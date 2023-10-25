using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
