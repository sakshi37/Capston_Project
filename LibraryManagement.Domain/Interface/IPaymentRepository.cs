using LibraryManagement.Domain.Models;

namespace LibraryManagement.Domain.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
    }
}
