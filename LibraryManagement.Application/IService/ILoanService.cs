using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface ILoanService
    {
        Task<Loan> AddLoan(Loan loan);
        //Task<Loan> GetLoanByUser(ApplicationUser Id);
    }
}
