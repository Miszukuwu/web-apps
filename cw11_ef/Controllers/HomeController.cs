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
            if (ModelState.IsValid)
            {
                _context.Editors.Add(editor);
                _context.SaveChanges();
                return RedirectToAction("Editors");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateEditor(int id)
        {
            Editor? toEdit = _context.Editors.FirstOrDefault(item => item.Id == id);
            if (toEdit != null)
                return View(toEdit);
            else
                return RedirectToAction("Editors"); 
        }
        [HttpPost]
        public IActionResult UpdateEditor(Editor editor)
        {
            if (ModelState.IsValid)
            {
                _context.Editors.Update(editor);
                _context.SaveChanges();
                return RedirectToAction("Editors");
            }
            return View(editor);
        }
        [HttpGet]
        public IActionResult DeleteEditor(int? id)
        {
            Editor? toDelete = _context.Editors.FirstOrDefault(item => item.Id == id);
            if (toDelete != null)
            {
                return View(toDelete);
            }
            return RedirectToAction("Editors");
        }
        [HttpPost]
        public IActionResult DeleteEditor(Editor toDelete)
        {
            if (toDelete != null)
            {
                _context.Editors.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Editors");
        }
        public ActionResult Editors()
        {
            return View(_context.Editors.ToList());
        }
    }
}
