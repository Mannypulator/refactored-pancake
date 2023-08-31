using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Dto;
using Food.Responses;
using Food.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BUAController : ControllerBase
    {
        private IBUAService _service;

        public BUAController(IBUAService service)
        {
            _service = service;
        }

        [HttpGet("validate-order")]
        [ProducesResponseType(typeof(GenericResponse<ValidateResponse>), 200)]
        public async Task<IActionResult> ValidateOrderAsync(string orderId)
        {
            var response = await _service.ValidateOrderAsync(orderId);
            return Ok(response);
        }

        [HttpPost("verify-payment")]
        [ProducesResponseType(typeof(GenericResponse<VerifyPaymentResponse>), 200)]
        public async Task<IActionResult> VerifyPaymentAsync(VerifyPaymentDto request)
        {
            var response = await _service.VerifyPaymentAsync(request);
            return Ok(response);
        }
    }
}
