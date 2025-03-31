using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Loan> GetLoanById(int loanId)
        {
            var loan = await _appContext.loans.FirstOrDefaultAsync(loan => loan.Id == loanId);
            return loan;
        }

        public async Task<IEnumerable<Loan>> GetLoansByUser(string userId)
        {
            var loans = await _appContext.loans.Where(loan => loan.UserId == userId).ToListAsync();
            return loans;
        }

    }
}
