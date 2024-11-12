using cw6.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class MoviesModel : PageModel
{
    public List<Movie> Movies { get; set; }
    private MoviesRepo _repo;


    public MoviesModel() {
        _repo = new MoviesRepo();
    }

    public void OnGet() {
        Movies = _repo.Movies ?? new List<Movie>();
    }
}