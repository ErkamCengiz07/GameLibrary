using GameLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{

    public class SecurityController : Controller
    {
        private readonly GameLibraryDbContext _context;

        public SecurityController(GameLibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userInDb != null)
            {
                return RedirectToAction("Index", "Game");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı. Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }

        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Security");
        }
    }
}
