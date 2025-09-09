using cw11_ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace cw11_ef.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksContext _context;
        public HomeController(BooksContext context)
        {
            _context = context;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddEditor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEditor(Editor editor)
        {
            System.Console.WriteLine("nazwa " + editor.Name);
            if (ModelState.IsValid)
            {
                _context.Editors.Add(editor);
                _context.SaveChanges();
                return RedirectToAction("Editors");
            }
            return View();
        }
        public IActionResult DeleteEditor(int id)
        {
            _context.Editors.Remove(_context.Editors.Find());
            return RedirectToAction("Editors");
        }
        public ActionResult Editors()
        {
            return View(_context.Editors.ToList());
        }
    }
}
