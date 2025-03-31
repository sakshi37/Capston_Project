using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;

namespace LibraryManagement.Infrastucture.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly AppDbContext _appDbContext;
        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            await _appDbContext.payments.AddAsync(payment);
            var addedPayment = await _appDbContext.SaveChangesAsync();
            return payment;
        }
    }
}
