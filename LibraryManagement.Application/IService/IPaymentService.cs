using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface IPaymentService
    {
        Task<Payment> AddPayment(Payment pay);
    }
}
