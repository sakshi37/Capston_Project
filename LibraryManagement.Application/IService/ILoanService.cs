using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface ILoanService
    {
        Task<Loan> AddLoan(Loan loan);
        Task<IEnumerable<Loan>> GetLoansByUser(string userId);
        Task<Loan> GetLoanById(int loanId);
        Task Update(int loanId);
    }
}
