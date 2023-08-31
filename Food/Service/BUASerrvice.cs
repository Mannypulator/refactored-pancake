using Food.Dto;
using Food.HttpService.Requests;
using Food.HttpService.Service;
using Food.Requests;
using Food.Responses;

namespace Food.Service;

public class BUASerrvice : IBUAService
{
    private readonly IHttpService _httpService;
    private readonly IConfiguration _configuration;

    public BUASerrvice(IHttpService httpService, IConfiguration configuration)
    {
        _httpService = httpService;
        _configuration = configuration;
    }


    public async Task<GenericResponse<ValidateResponse>> ValidateOrderAsync(string orderId)
    {
        
        //NOTE: You should do validations before calling methods that make calls to third porty APIS
        var validateRequest = new ValidateRequest
        {
            OrderId = orderId,
        };

        var validateResponse = await ValidateAsync(validateRequest);

        if (validateResponse.Status == "100")
        {
            return new GenericResponse<ValidateResponse>
            {
                ResponseMsg = "Invalid OrderId",
                ResponseCode = "01"
            };
            
        }

        return new GenericResponse<ValidateResponse>
        {
            ResponseMsg = "Success",
            ResponseCode = "00",
            Data = validateResponse
        };
    }

    public async Task<GenericResponse<VerifyPaymentResponse>> VerifyPaymentAsync(VerifyPaymentDto verifyPaymentDto)
    {
        //NOTE: You should do validations before calling methods that make calls to third porty APIS

        var verifyPaymentRequest = new VerifyPaymentRequest
        {
            BankTransactionId = verifyPaymentDto.BankTransactionId,
            CreditAccountNumber = verifyPaymentDto.CreditAccountNumber
        };

        var verifyPaymentResponse = await VerifyPaymentHttpAsync(verifyPaymentRequest);

        if (verifyPaymentResponse.Status == "100")
        {
            return new GenericResponse<VerifyPaymentResponse>()
            {
                ResponseCode = "01",
                ResponseMsg = "Record Not Found"
            };
        }

        return new GenericResponse<VerifyPaymentResponse>
        {
            ResponseCode = "00",
            ResponseMsg = "Success",
            Data = verifyPaymentResponse
        };
    }


    private async Task<ValidateResponse> ValidateAsync(ValidateRequest validateRequest)
    {
        string url = $"{_configuration.GetSection("BUA-API")["url"]}/validate";

        var request = new PostRequest<ValidateRequest>
        {
            Url = url,
            Data = validateRequest
        };

        var response = await _httpService.SendPostRequestAsync<ValidateResponse, ValidateRequest>(request);
        return response;
    }

    private async Task<VerifyPaymentResponse> VerifyPaymentHttpAsync(VerifyPaymentRequest verifyPaymentRequest)
    {
        string url = $"{_configuration.GetSection("BUA-API")["url"]}/verify_payment";

        var request = new PostRequest<VerifyPaymentRequest>()
        {
            Url = url,
            Data = verifyPaymentRequest
        };

        var response = await _httpService.SendPostRequestAsync<VerifyPaymentResponse, VerifyPaymentRequest>(request);
        return response;

    }
}