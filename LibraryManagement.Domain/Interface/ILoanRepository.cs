using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface ILoanRepository
    {
        Task<Loan> AddLoan(Loan loan);
        //Task<Loan> GetLoanByUser(ApplicationUser id);
    }
}
