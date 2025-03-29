using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthor(Author author);
        Task<IEnumerable<Author>> GetAllAuthor();
    }
}
