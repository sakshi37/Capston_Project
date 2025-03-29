using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface IAuthorService
    {
        Task<Author> AddAuthor(Author author);
        Task<IEnumerable<Author>> GetAllAuthor();
    }
}
