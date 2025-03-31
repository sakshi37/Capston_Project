using AutoMapper;
using LibraryManagement.Api.DTO;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
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
        public async Task<IActionResult> AddLoan([FromBody] LoanRequestDto loanRequest)
        {
            var loan = _mapper.Map<Loan>(loanRequest);
            var addedLoan = await _loanService.AddLoan(loan);
            return Ok(addedLoan);
        }

        //public async Task<IActionResult> GetLoanByUser()
        //{
        //    var loan = await _loanService.GetLoanByuser();
        //    return Ok(loan);
        //}


    }

}
