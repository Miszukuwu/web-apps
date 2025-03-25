using Microsoft.AspNetCore.Mvc;

namespace inf03styczen202101.Controllers;

using Models;

public class FootballController : Controller {
    private FootballRepo _footballRepo;
    public FootballController(IConfiguration configuration) {
        _footballRepo = new FootballRepo(configuration.GetConnectionString("FootballDB"));
    }

    [HttpGet]
    public IActionResult Index() {
        List<Match> matches = _footballRepo.GetMatches();
        ViewBag.Matches = matches;
        ViewBag.Players = new List<Player>();
        return View();
    }
    [HttpPost]
    public IActionResult Index(int id) {
        List<Match> matches = _footballRepo.GetMatches();
        List<Player> players = _footballRepo.GetPositionPlayers(id);
        ViewBag.Matches = matches;
        ViewBag.Players = players;
        return View();
    }
}
