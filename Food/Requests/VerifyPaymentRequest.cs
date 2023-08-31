using Newtonsoft.Json;

namespace Food.Requests;

public class VerifyPaymentRequest
{
    [JsonProperty("creditaccountnumber")]
    public string CreditAccountNumber { get; set; }
    [JsonProperty("bank_transaction_id")]
    public string BankTransactionId { get; set; }
}