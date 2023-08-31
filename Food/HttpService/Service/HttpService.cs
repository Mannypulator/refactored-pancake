using System.Text;
using Food.HttpService.Requests;
using Newtonsoft.Json;

namespace Food.HttpService.Service;

public class HttpService :IHttpService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<HttpService> _logger;
    
    public HttpService(IHttpClientFactory clientFactory, IConfiguration configuration, ILogger<HttpService> logger)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
        _logger = logger;
    }

   

    public async Task<T> SendPostRequestAsync<T, U>(PostRequest<U> request)
    {
        var client = _clientFactory.CreateClient();
        var message = new HttpRequestMessage
        {
            RequestUri = new Uri(request.Url),
            Method = HttpMethod.Post
        };
        message.Headers.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Clear();
        //client.DefaultRequestHeaders.Add("X-CID", clientSecretKey);
        var data = JsonConvert.SerializeObject(request.Data);
        _logger.LogInformation("Sending POST request to {Url} with Body {data}", message.RequestUri, data);
        message.Content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await client.SendAsync(message);
        var content = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Response from {Url} is {response}", message.RequestUri, content);
        return JsonConvert.DeserializeObject<T>(content);
    }
}