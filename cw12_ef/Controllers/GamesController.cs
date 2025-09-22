using cw12_ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cw12_ef.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamesContext _context;
        public GamesController(GamesContext context)
        {
            _context = context;
        }
        // GET: GamesController
        public ActionResult List()
        {
            return View(_context.Games.ToList());
        }
        [HttpGet]
        public ActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View();
        }
    }
}
