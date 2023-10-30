using Lezita2.Context;
using Lezita2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lezita2.Controllers
{
    public class LoginController : Controller
    {
        LezitaDbContext _context = new();
        public async Task Login(User user)
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

        public async Task Logout(User user)
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
        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
    }
}
