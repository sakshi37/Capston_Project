using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.Service
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorRepository _DbAuthorRepo;
        public AuthorService(IAuthorRepository IAuthorRepositoryDbContext)
        {

            _DbAuthorRepo = IAuthorRepositoryDbContext;

        }

        public async Task<Author> AddAuthor(Author author)
        {
            var addedAuthor = await _DbAuthorRepo.AddAuthor(author);
            return addedAuthor;
        }

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            var allAuthor = await _DbAuthorRepo.GetAllAuthor();
            return allAuthor;
        }
    }
}
