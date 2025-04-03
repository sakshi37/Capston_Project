using System.Security.Claims;
using AutoMapper;
using LibraryManagement.Api.DTO;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly IPaymentService _paymentService;
        readonly IMapper _mapper;
        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Payment> AddPayment([FromBody] PaymentRequestDto paymentDto)
        {
            var pay = _mapper.Map<Payment>(paymentDto);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            pay.UserId = userId;
            var addedPay = await _paymentService.AddPayment(pay);
            return addedPay;
        }


    }
}
