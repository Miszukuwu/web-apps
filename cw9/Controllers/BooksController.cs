using cw9.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw9.Controllers;

public class BooksController : Controller
{
    // GET
    public IActionResult List() {
        return View(MyBooks.GetBooks());
    }
}
