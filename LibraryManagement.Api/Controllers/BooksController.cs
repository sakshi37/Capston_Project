using AutoMapper;
using LibraryManagement.Api.DTO;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBookService _dbBookService;
        readonly IMapper _mapper;
        public BooksController(IBookService DbBookService, IMapper mapper)
        {

            _mapper = mapper;
            _dbBookService = DbBookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var allBooks = await _dbBookService.GetAllBooks();

            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookRequestDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var bookAdded = await _dbBookService.AddBook(book);
            return Ok(bookAdded);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetBookByID(int id)
        //{
        //    var book = await _dbBookService.GetBookById(id);
        //    return Ok(book);
        //}

    }
}
