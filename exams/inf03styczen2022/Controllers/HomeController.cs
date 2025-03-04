using Microsoft.AspNetCore.Mvc;

namespace inf03styczen2022Controllers;

using inf03styczen2022.Models;
using MySql.Data.MySqlClient;

public class HomeController : Controller {
    private readonly string _connectionString;
    public HomeController(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("mysql");
    }
    // GET
    public IActionResult Index() {
        return View();
    }
    [HttpPost]
    public IActionResult Rezerwacja(Reservation reservation) {
        MySqlConnection connection = new MySqlConnection();
        return View();
    }
}
