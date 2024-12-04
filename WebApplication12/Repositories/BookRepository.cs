
using WebApplication12.Models;
using WebApplication12.Repositories;

namespace WebApplication12.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book>();

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            // Đảm bảo ID là duy nhất
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Image = book.Image;
            }
        }

        public void DeleteBook(int id)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
    }
}