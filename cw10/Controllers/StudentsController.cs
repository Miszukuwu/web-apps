using cw10.Models;
using cw10.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentRepo _studentRepo;
    private readonly string? _connectionString;
    public StudentsController(IConfiguration configuration) {
        // _studentRepo = new FakeStudentRepo();
        _connectionString = configuration.GetConnectionString("MySql");
        _studentRepo = new MySqlStudentRepo(_connectionString);
    }

    // GET
    public IActionResult List() {
        return View(_studentRepo.GetStudents());
    }
    [HttpGet]
    public IActionResult Create() {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(MyStudent student) {
        if (ModelState.IsValid) {
            _studentRepo.AddStudent(student);
            return RedirectToAction("List");
        }
        return View();
    }
    public IActionResult Delete(int? id) {
        if (id != null) {
            _studentRepo.DeleteStudent(id);
        }
        return RedirectToAction("List");
    }
}
