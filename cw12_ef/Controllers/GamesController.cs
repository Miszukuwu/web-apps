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
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteGame(int id)
        {
            Game? toDelete = _context.Games.FirstOrDefault(e => e.Id == id);
            if (toDelete != null)
            {
                _context.Games.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult EditGame(int id)
        {
            Game? toEdit = _context.Games.FirstOrDefault(e => e.Id == id);
            if (toEdit != null)
            {
                return View(toEdit);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult EditGame(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
