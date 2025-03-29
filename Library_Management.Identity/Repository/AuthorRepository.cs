using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastucture.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly AppDbContext _appDbCOntext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbCOntext = appDbContext;

        }
        public async Task<Author> AddAuthor(Author author)
        {
            await _appDbCOntext.authors.AddAsync(author);
            var addedAuthor = await _appDbCOntext.SaveChangesAsync();
            return author;

        }
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            var allAuthors = await _appDbCOntext.authors.ToListAsync();
            return allAuthors;
        }
    }
}
