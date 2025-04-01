using AutoMapper;
using LibraryManagement.Api.DTO;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IAuthorService _DbContextAuthor;
        readonly IMapper _mapper;
        public AuthorsController(IAuthorService DbCOntextAuthorService, IMapper mapper)
        {
            _mapper = mapper;
            _DbContextAuthor = DbCOntextAuthorService;

        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorRequestDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
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
