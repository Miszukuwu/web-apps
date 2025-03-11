using Microsoft.AspNetCore.Mvc;

namespace inf03styczen2022Controllers;

using inf03styczen2022.Models;
using MySql.Data.MySqlClient;

public class HomeController : Controller {
    private RepoReservations _repo;
    public HomeController(IConfiguration configuration) {
        _repo = new RepoReservations(configuration);
    }
    // GET
    public IActionResult Index() {
        return View();
    }
    [HttpPost]
    public IActionResult Rezerwacja(Reservation reservation) {
        if (reservation == null) {
            return RedirectToAction("Index");
        }
        reservation.TableNumber = 1;
        _repo.addReservation(reservation);
        return View();
    }
}
