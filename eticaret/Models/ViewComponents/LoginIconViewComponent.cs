using Lezita2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lezita2.Models.ViewComponents
{
    public class LoginIconViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            var UserName = HttpContext.Request.Cookies["UserName"];
            if (UserName is not null) 
                ViewBag.UserName = UserName.ToString();
            return View(); 
        }
    }
}
