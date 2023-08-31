using Newtonsoft.Json;

namespace Food.Responses;

public class VerifyPaymentResponse : BUABaseResponse
{
    [JsonProperty("transactionid")]
    public string TransactionId { get; set; }
}