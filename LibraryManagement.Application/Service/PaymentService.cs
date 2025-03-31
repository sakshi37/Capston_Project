using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;

namespace LibraryManagement.Application.Service
{
    public class PaymentService : IPaymentService
    {
        readonly IPaymentRepository _payRepo;
        readonly ILoanService _loanService;
        public PaymentService(IPaymentRepository paymentRepository, ILoanService loanService)
        {
            _loanService = loanService;
            _payRepo = paymentRepository;
        }

        public async Task<Payment> AddPayment(Payment pay)
        {

            //startDate EndDate BookPrice 
            var loan = await _loanService.GetLoanById(pay.LoanId);

            var startDate = loan.StartDate;
            var endDate = loan.EndDate;
            var currentDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            var bookPrice = loan.BorrowedAtPrice;

            var days = (decimal)(endDate - startDate).TotalDays;
            var rate = (decimal)1 / 100;
            var amount = days * rate;

            var total = amount;

            var diff = (decimal)(endDate - currentDate).TotalDays;
            if (diff >= 0)
            {
                var discountRate = (decimal)0.5 / 100;
                var absDiff = Math.Ceiling(diff);
                var discount = absDiff * discountRate * bookPrice;
                total = total - discount;
            }
            else
            {
                var penaltyRate = (decimal)2 / 100;
                var absDiff = Math.Ceiling(Math.Abs(diff));

                var penalty = absDiff * penaltyRate * bookPrice;
                total = total + penalty;
            }
            pay.ReturnedAtDate = currentDate;
            pay.PaidAmount = total;
            var addPay = await _payRepo.AddPayment(pay);
            return addPay;
        }
    }
}
