using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
