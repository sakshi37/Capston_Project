using System.Security.Claims;
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
    public class LoanController : ControllerBase
    {
        private readonly int MAX_BORROW_COUNT = 20;
        readonly ILoanService _loanService;
        readonly IMapper _mapper;

        public LoanController(ILoanService iLoanService, IMapper mapper)
        {
            _mapper = mapper;
            _loanService = iLoanService;
        }

        [HttpPost]
        public async Task<ActionResult<LoanResponseDto>> AddLoan([FromBody] LoanRequestDto loanRequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var mappedLoan = _mapper.Map<Loan>(loanRequest);
            Console.WriteLine("hellow orlddjewfkj");
            mappedLoan.UserId = userId;

            var loans = await _loanService.GetLoansByUser(userId);

            var currentBorrowedCount = loans.Count(loan => loan.IsReturn == false);
            if (currentBorrowedCount >= MAX_BORROW_COUNT)
            {
                return BadRequest(new { message = $"Cannot borrow more than {MAX_BORROW_COUNT} books" });
            }

            var alreadyBorrowed = loans.Any(loan => loan.BookId == mappedLoan.BookId && loan.IsReturn == false);
            if (alreadyBorrowed)
            {
                return BadRequest(new { message = $"Cannot borrow already borrowed book" });
            }

            var addedLoan = await _loanService.AddLoan(mappedLoan);
            return Ok(addedLoan);
        }

        [HttpGet]
        public async Task<IActionResult> GetLoansByUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var loan = await _loanService.GetLoansByUser(userId);
            return Ok(loan);
        }
    }
}