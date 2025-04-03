using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> GetPaymentById(int id);
        Task<Payment> UpdatePayment(Payment payment);
    }
}
