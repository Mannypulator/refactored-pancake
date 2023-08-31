using Food.HttpService.Requests;

namespace Food.HttpService.Service;

public interface IHttpService
{
    Task<T> SendPostRequestAsync<T, U>(PostRequest<U> request);
}