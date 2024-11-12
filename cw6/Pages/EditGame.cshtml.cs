using cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages
{
    public class EditGameModel : PageModel
    {
        [BindProperty]
        public Game MyGame { get; set; }
        public List<string>? Genres { get; set; }
        private readonly GamesRepo _repo = new GamesRepo();

        public EditGameModel() {
            Genres = new List<string> {
                "RPG", "Action", "Adventure", "Rougelike",
                "Sandbox", "Simulation", "Shooter", "Party"
            };
        }

        public void OnGet(int id) {
            ViewData["Genres"] = Genres;
            var gameToEdit = _repo.GetById(id);
            if (gameToEdit != null) {
                MyGame = gameToEdit;
            }
        }
        public IActionResult OnPost() {
            ViewData["Genres"] = Genres;
            if (ModelState.IsValid) {
                var game = MyGame;
                _repo.UpdateGame(game);
                return RedirectToPage("Games");
            }

            ViewData["Message"] = ModelState;
            return Page();
        }
    }
}