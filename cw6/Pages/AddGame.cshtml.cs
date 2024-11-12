using cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class AddGameModel : PageModel
{
    [BindProperty]
    public Game? MyGame { get; set; }
    public List<string>? Genres { get; set; }
    public void OnGet() {
        ViewData["Genres"] = Genres;
        ViewData["Message"] = "Dopiero wyświetlamy formularz";
    }
    public IActionResult OnPost() {
        ViewData["Genres"] = Genres;
        if (MyGame == null) {
            ViewData["Message"] = "Brak danych";
            return Page();
        }
        if (ModelState.IsValid) {
            GamesRepo repo = new GamesRepo();
            repo.AddGame(MyGame);
            ViewData["Message"] = "Movie added";
            return RedirectToPage("Games");
        } else {
            ViewData["Message"] = "Invalid movie";
        }
        return Page();
    }
    public AddGameModel() {
        Genres = new List<string> {
            "RPG", "Action", "Adventure", "Rougelike",
            "Sandbox", "Simulation", "Shooter", "Party"
        };
    }
}