using cw9.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw9.Controllers;

public class ColorsController : Controller
{
    // GET
    public IActionResult Show() {
        return View(ColorsRepo.GetColors());
    }
}
