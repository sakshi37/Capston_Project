using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        readonly IBookService _dbBookService;
        public BookController(IBookService DbBookService)
        {

            _dbBookService = DbBookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var allBooks = await _dbBookService.GetAllBooks();
            if (allBooks == null)
            {
                Console.WriteLine("Data could not found");

            }

            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var bookAdded = await _dbBookService.AddBook(book);
            return Ok(bookAdded);
        }
    }
}
