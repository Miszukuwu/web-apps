using cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages
{
    public class DeleteGameModel : PageModel
    {
        private GamesRepo _repo = new GamesRepo();
        public IActionResult OnGet(int? id) {
            if (id != null) {
                Game? game = _repo.GetById(id);
                if (game != null)
                    _repo.DeleteGame(game);
            }
            return RedirectToPage("Games");
        }
    }
}