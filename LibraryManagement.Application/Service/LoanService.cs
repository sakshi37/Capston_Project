using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.Service
{
    public class LoanService : ILoanService
    {
        readonly ILoanRepository _loanRepository;
        readonly IBookService _bookService;
        public LoanService(ILoanRepository loanRepository, IBookService bookService)
        {
            _loanRepository = loanRepository;
            _bookService = bookService;

        }

        public async Task<Loan> AddLoan(Loan loan)
        {
            loan.StartDate = DateTime.Today;
            loan.EndDate = loan.EndDate.Date.AddDays(1).AddTicks(-1);
            loan.IsReturn = false;

            var book = await _bookService.GetBookById(loan.BookId);

            loan.BorrowedAtPrice = book.Price;
            var addedLoan = await _loanRepository.AddLoan(loan);
            return addedLoan;

        }

        //public async Task<Loan> GetLoanByUser(string Id)
        //{
        //    var user = await _bookService.GetLoanByUser(ApplicationUser Id);
        //    return user;
        //}
    }
}
