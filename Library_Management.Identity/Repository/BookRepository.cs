using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repository
{
    public class BookRepository : IBookRepository

    {
        readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _appDbContext.books.ToListAsync();
            return books;

        }

        public async Task<Book> AddBook(Book book)
        {
            await _appDbContext.books.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
            return book;
        }
        public async Task<Book> GetBookById(int id)
        {
            var books = await _appDbContext.books.FirstOrDefaultAsync(x => x.Id == id);
            return books;
        }
    }
}
