using Lezita2.Context;
using Lezita2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lezita2.Controllers
{
    public class LoginController : Controller
    {
        LezitaDbContext _context = new();
        public async Task LoginActivity(User user)
        {
            // Giriş işlemleri...

            // Aktiviteyi log tablosuna ekleme
            var log = new UserActivityLog
            {
                UserId = user.Id,
                ActivityType = "Login",
                Timestamp = DateTime.Now
            };
            //_context.UserActivityLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task LogoutActivity(User user)
        {
            // Çıkış işlemleri...

            // Aktiviteyi log tablosuna ekleme
            var log = new UserActivityLog
            {
                UserId = user.Id,
                ActivityType = "Logout",
                Timestamp = DateTime.Now
            };
            //_context.UserActivityLogs.Add(log);
            await _context.SaveChangesAsync();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            //UserName password kontrol - authentication işlemleri - LoginIcon için cookie fırlatıldı
            HttpContext.Response.Cookies.Append("UserName", "Yavuzhan");
            return RedirectToAction("Index","Home");
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            //Cookie silindi ve sonrasında authentication işlemleri yapılacak...
            HttpContext.Response.Cookies.Delete("UserName");
            return RedirectToAction("Index");
        }
        
    }
}
