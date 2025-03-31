using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;

namespace LibraryManagement.Infrastucture.Repository
{
    public class LoanRepository : ILoanRepository
    {
        readonly AppDbContext _appContext;
        public LoanRepository(AppDbContext appDbContext)
        {

            _appContext = appDbContext;
        }

        public async Task<Loan> AddLoan(Loan loan)
        {
            await _appContext.loans.AddAsync(loan);
            await _appContext.SaveChangesAsync();
            return loan;

        }
    }
}
