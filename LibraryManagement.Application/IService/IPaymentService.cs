using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.IService
{
    public interface IPaymentService
    {
        Task<Payment> AddPayment(Payment pay);
        Task<Payment> GetPaymentById(int id);
        Task<Payment> UpdatePayment(Payment pay);
    }
}
