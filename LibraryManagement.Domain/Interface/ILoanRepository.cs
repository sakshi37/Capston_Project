using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface ILoanRepository
    {
        Task<Loan> AddLoan(Loan loan);
        Task<IEnumerable<Loan>> GetLoansByUser(string userId);
        Task<Loan> GetLoanById(int loanId);

    }
}
