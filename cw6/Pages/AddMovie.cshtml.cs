using cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class AddMovieModel : PageModel {
    [BindProperty]
    public Movie? MyMovie { get; set; }
    public List<string>? Genres {get; set;}
    public void OnGet(){
        ViewData["Genres"] = Genres;
        ViewData["Message"] = "Dopiero wywitlamy formularz";
    }
    public IActionResult OnPost(){
        ViewData["Genres"] = Genres;
        if (MyMovie == null){
            ViewData["Message"] = "Brak danych";
            return Page();
        }
        if(ModelState.IsValid){
            MoviesRepo repo = new MoviesRepo();
            repo.AddMovie(MyMovie);
            ViewData["Message"] = "Movie added";
            return RedirectToPage("Movies");
        } else {
            ViewData["Message"] = "Invalid movie";
        }
        return Page();      
    }
    public AddMovieModel(){
        Genres = new List<string>{"Acton", "Crime", "Sci-Fi", "Drama", "Action", "Fantasy"};
    }
}