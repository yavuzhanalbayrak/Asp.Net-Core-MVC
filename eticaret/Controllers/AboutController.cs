using Microsoft.AspNetCore.Mvc;
//hakkında
namespace Lezita2.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
