using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> AddBook(Book book);

        Task<Book> GetBookById(int id);


    }
}
