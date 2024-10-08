using cw6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class GamesModel : PageModel {
    public List<Game> Games { get; set; }
    GamesRepo _repo;

    public GamesModel(){
        _repo = new GamesRepo("games.json");
    }

    public void OnGet(){
        Games = _repo.Games?? new List<Game>();
    }
}