using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IAuthorService _DbContextAuthor;
        public AuthorsController(IAuthorService DbCOntextAuthorService)
        {
            _DbContextAuthor = DbCOntextAuthorService;

        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var addedAuthor = await _DbContextAuthor.AddAuthor(author);
            return Ok(addedAuthor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var allAuthor = await _DbContextAuthor.GetAllAuthor();
            return Ok(allAuthor);
        }
    }
}
