using Microsoft.AspNetCore.Mvc;

namespace cw9.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index() {
        return View();
    }
}
