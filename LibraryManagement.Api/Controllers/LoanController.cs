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
            var loan = _mapper.Map<Loan>(loanRequest);
            var addedLoan = await _loanService.AddLoan(loan);
            return Ok(addedLoan);
        }
        [HttpGet]
        public async Task<IActionResult> GetLoansByUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var loan = await _loanService.GetLoansByUser(userId);
            return Ok(loan);
        }




    }

}
