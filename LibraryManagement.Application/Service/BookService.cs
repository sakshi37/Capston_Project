using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.Service
{
    public class BookService : IBookService
    {
        readonly IBookRepository _dbBookRepository;
        public BookService(IBookRepository IDbBookRepository)

        {
            _dbBookRepository = IDbBookRepository;
        }

        public async Task<Book> AddBook(Book book)
        {
            var addedBook = await _dbBookRepository.AddBook(book);
            return addedBook;

        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var allBook = await _dbBookRepository.GetAllBooks();
            return allBook;
        }


    }
}
