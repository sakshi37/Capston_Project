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

        //[HttpPost]
        //public async Task<Payment> UpdatePayment([FromBody] PaymentRequestDto)

        //[HttpPost]
        //public async Task<IActionResult> AddPayment([FromBody] PaymentRequestDto paymentDto)
        //{
        //    try
        //    {
        //        if (paymentDto == null)
        //        {
        //            return BadRequest("Payment request data is null.");
        //        }

        //        if (_mapper == null)
        //        {
        //            return StatusCode(500, "Mapper is not initialized.");
        //        }

        //        var pay = _mapper.Map<Payment>(paymentDto);

        //        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        //        if (userIdClaim == null)
        //        {
        //            return Unauthorized("User ID not found in token.");
        //        }

        //        pay.UserId = userIdClaim.Value;

        //        if (_paymentService == null)
        //        {
        //            return StatusCode(500, "Payment service is not initialized.");
        //        }

        //        var addedPay = await _paymentService.AddPayment(pay);
        //        return Ok(addedPay);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal Server Error: {ex.Message}");
        //    }
        //}

    }
}
