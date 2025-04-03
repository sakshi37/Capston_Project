using LibraryManagement.Domain.Interface;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Payment> GetPaymentById(int id)
        {
            var payment = await _appDbContext.payments.FirstOrDefaultAsync(i => i.PaymentId == id);
            return payment;
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _appDbContext.payments.Update(payment);
            var update = await _appDbContext.SaveChangesAsync();
            return payment;
        }
    }
}
