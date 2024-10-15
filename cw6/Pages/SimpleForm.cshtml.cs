using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw6.Pages;

public class SimpleForm : PageModel {
    public void OnGet(){
        var request = Request;
        ViewData["method"] = "GET";
    }
    public void OnPost(){
        ViewData["method"] = "POST";
        var request = Request;
    }
}