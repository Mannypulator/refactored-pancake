using Food.Dto;
using Food.Responses;

namespace Food.Service;

public interface IBUAService
{
    Task<GenericResponse<ValidateResponse>> ValidateOrderAsync(string orderId);
    
    Task<GenericResponse<VerifyPaymentResponse>> VerifyPaymentAsync(VerifyPaymentDto verifyPaymentDto);
}