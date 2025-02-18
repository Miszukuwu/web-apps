using Microsoft.AspNetCore.Mvc;

namespace cw10b.Controllers;

using System.Configuration;
using Models;

public class GamesController : Controller {
    private readonly GamesRepo _gamesRepo;
    public GamesController(IConfiguration configuration) {
        _gamesRepo = new GamesRepo(configuration.GetConnectionString("gamesDB"));
    }
    // GET
    public IActionResult List() {
        return View(_gamesRepo.GetGames());
    }
    [HttpGet]
    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Game game) {
        if (!ModelState.IsValid) {
            return View();
        }
        _gamesRepo.AddGame(game);
        return RedirectToAction("List");
    }
    public IActionResult Delete(int? id) {
        if (id != null) {
            _gamesRepo.DeleteGame(id);
        }
        return RedirectToAction("List");
    }
    public IActionResult Update(Game game) {
        return View(game);
    }
    // TODO: Edytowanie i walidacja po stronie klienta (javascript)
}
