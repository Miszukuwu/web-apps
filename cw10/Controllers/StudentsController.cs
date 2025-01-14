using cw10.Models;
using cw10.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentRepo _studentRepo;
    public StudentsController() {
        _studentRepo = new FakeStudentRepo();
    }

    // GET
    public IActionResult List() {
        return View(_studentRepo.GetStudents());
    }
    public IActionResult Create() {
        return View();
    }
}
