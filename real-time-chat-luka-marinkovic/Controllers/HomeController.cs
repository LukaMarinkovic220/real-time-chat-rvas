using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using real_time_chat_luka_marinkovic.Models;

namespace real_time_chat_luka_marinkovic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var trenutni_korisnik = await _userManager.GetUserAsync(User);

            // ako korisnik nije ulogovan
            if (trenutni_korisnik == null)
            {
                return View();
            }

            // ako korisnik jeste ulogovan
            var korisnici = _userManager.Users.Where(k => k.Id != trenutni_korisnik.Id).ToList();
            return View("LogiranIndex", korisnici);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
