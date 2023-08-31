using Newtonsoft.Json;

namespace Food.Requests;

public class ValidateRequest
{
    [JsonProperty("orderid")]
    public string OrderId { get; set; }
}