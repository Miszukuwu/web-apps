using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw5.Pages;

public class index1 : PageModel {
    public int FajnaLiczba { get; set; }
    public void OnGet(){
        Random rnd = new Random();
        FajnaLiczba = rnd.Next(1, 100);
        
    }
}