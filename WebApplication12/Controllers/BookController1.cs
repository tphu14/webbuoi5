using Microsoft.AspNetCore.Mvc;

using WebApplication12.Models;
using WebApplication12.Repositories;

namespace WebApplication12.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        // Dependency Injection qua Constructor
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Action Index - Hiển thị danh sách sách
        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        // Action Create - Thêm sách mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Action Edit - Chỉnh sửa sách
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Action Delete - Xóa sách
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepository.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        // Action Details - Chi tiết sách
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}