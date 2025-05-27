using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.SignalR;

using real_time_chat_luka_marinkovic.Data;
using real_time_chat_luka_marinkovic.Models;

namespace real_time_chat_luka_marinkovic.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Start(string userId)
        {
            var trenutniKorisnik = await _userManager.GetUserAsync(User);
            var drugiKorisnik = await _userManager.FindByIdAsync(userId);

            Console.WriteLine("Poziva se funkcija 'Start' iz ChatController.");

            var messages = _context.Messages
                .Where(m => (m.SenderId == trenutniKorisnik.Id && m.ReceiverId == userId) ||
                            (m.SenderId == userId && m.ReceiverId == trenutniKorisnik.Id))
                .OrderBy(m => m.Timestamp)
                .ToList();

            ViewBag.trenutniKorisnikId = trenutniKorisnik.Id;
            ViewBag.drugiKorisnik = drugiKorisnik;

            return View(messages);
        }
    }
}
