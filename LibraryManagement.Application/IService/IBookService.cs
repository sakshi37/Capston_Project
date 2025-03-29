using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> AddBook(Book book);
        Task<Book> GetBookById(int id);
    }
}
