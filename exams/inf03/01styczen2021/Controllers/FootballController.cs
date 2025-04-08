using Microsoft.AspNetCore.Mvc;

namespace inf03styczen202101.Controllers;

using Models;

public class FootballController : Controller {
    private FootballRepo _footballRepo;
    public FootballController(IConfiguration configuration) {
        _footballRepo = new FootballRepo(configuration.GetConnectionString("footballDB"));
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
        List<Player> players = _footballRepo.GetPlayers(id);
        ViewBag.Matches = matches;
        ViewBag.Players = players;
        return View();
    }
    public IActionResult List() {
        List<Match> matches = _footballRepo.GetMatches();
        List<Player> players = _footballRepo.GetPlayers();
        ViewBag.Matches = matches;
        return View(players);
    }
    [HttpGet]
    public IActionResult Gallery() {
        ViewBag.Images = _footballRepo.GetImages();
        return View();
    }
    [HttpPost]
    public IActionResult Gallery(IFormFile image) {
        _footballRepo.AddImage(image);
        ViewBag.Images = _footballRepo.GetImages();
        return View();
    }
}
